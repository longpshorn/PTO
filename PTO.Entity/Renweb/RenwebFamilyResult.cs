using PTO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Entity.Renweb
{
    public class RenwebFamilyResult : AuditEntity<RenwebFamilyResult, int>
    {
        public string Student { get; set; }

        public string Grade { get; set; }

        public string Parents { get; set; }

        public string Home { get; set; }

        public string Work { get; set; }

        public string Other { get; set; }

        public string Address { get; set; }

        public int AddressID { get; set; }

        public int personID { get; set; }

        public string Email { get; set; }

        public bool IsProcessed { get; set; }

        private void AddOutputProperty(StringBuilder sb, string propertyName, string property)
        {
            if (!string.IsNullOrEmpty(property))
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }
                sb.AppendFormat("{0}: {1}", propertyName, property);
            }
        }

        private void AddOutputProperty(StringBuilder sb, string propertyName, int? property)
        {
            if (property != null)
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }
                sb.AppendFormat("{0}: {1}", propertyName, property);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            AddOutputProperty(sb, "Student", Student);
            AddOutputProperty(sb, "Grade", Grade);
            AddOutputProperty(sb, "Parents", Parents);
            AddOutputProperty(sb, "Home", Home);
            AddOutputProperty(sb, "Work", Work);
            AddOutputProperty(sb, "Other", Other);
            AddOutputProperty(sb, "Address", Address);
            AddOutputProperty(sb, "AddressID", AddressID);
            AddOutputProperty(sb, "personID", personID);
            AddOutputProperty(sb, "Email", Email);

            return sb.ToString();
        }

        public bool Equals(RenwebFamilyResult other)
        {
            if (other == null)
            {
                return false;
            }

            return ReferenceEquals(other, this) || (other.personID.Equals(personID) && !personID.Equals(default(int)));
        }

        public override bool Equals(object obj)
        {
            var entityBase = obj as RenwebFamilyResult;

            if (entityBase == null)
            {
                return false;
            }

            return ReferenceEquals(entityBase, this) || (entityBase.personID.Equals(personID) && !personID.Equals(default(int)));
        }

        public override int GetHashCode()
        {
            return personID.Equals(default(int)) ? base.GetHashCode() : personID.GetHashCode();
        }
    }
}
