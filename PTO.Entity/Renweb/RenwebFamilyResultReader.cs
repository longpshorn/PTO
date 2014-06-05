using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PTO.Entity.Renweb
{
    public class RenwebFamilyResultReader
    {
        private const string _resultsSource = "PTO.Entity.Renweb.renweb_results.xml";
        private const string _selector = "//*[local-name()='NewDataSet']/*[local-name()='Table']";

        private static IEnumerable<RenwebFamilyResult> _results;

        public static IEnumerable<RenwebFamilyResult> GetResults()
        {
            if (_results != null)
            {
                return _results;
            }

            var assembly = Assembly.GetExecutingAssembly();
            using (Stream file = assembly.GetManifestResourceStream(_resultsSource))
            {
                // Missing aggregate source
                if (file == null)
                {
                    Debug.Print("Warning: Could not find source file: {0}.  Ensure the source file has been configured as an Embedded Resource.", _resultsSource);
                    return null;
                }

                var document = new XmlDocument();
                document.Load(file);

                var nodes = document.SelectNodes(_selector);
                // Make sure the source has some results
                if (nodes == null)
                {
                    Debug.Print("Warning: Could not find any results in the source file: {0}.", _resultsSource);
                    return null;
                }

                var results = new List<RenwebFamilyResult>();
                foreach (XmlNode node in nodes)
                {
                    // Skip node if it doesn't have any child nodes
                    if (!node.HasChildNodes)
                    {
                        Debug.Print("Warning: Family result from source is not correctly configured. Missing child nodes.");
                        continue;
                    }

                    var result = new RenwebFamilyResult();
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        if (!string.IsNullOrEmpty(childNode.InnerText)) {
                            switch (childNode.Name)
                            {
                                case "Student":
                                    result.Student = childNode.InnerText;
                                    break;
                                case "Grade":
                                    result.Grade = childNode.InnerText;
                                    break;
                                case "Parents":
                                    result.Parents = childNode.InnerText;
                                    break;
                                case "Home":
                                    result.Home = childNode.InnerText;
                                    break;
                                case "Work":
                                    result.Work = childNode.InnerText;
                                    break;
                                case "Other":
                                    result.Other = childNode.InnerText;
                                    break;
                                case "Address":
                                    result.Address = childNode.InnerText;
                                    break;
                                case "AddressID":
                                    result.AddressID = int.Parse(childNode.InnerText);
                                    break;
                                case "personID":
                                    result.personID = int.Parse(childNode.InnerText);
                                    break;
                                case "Email":
                                    result.Email = childNode.InnerText;
                                    break;
                            }
                        }
                    }

                    // Add the new family result to the results list.
                    results.Add(result);
                }

                _results = results;
                Debug.Assert(results != null);

                return _results;
            }
        }
    }
}
