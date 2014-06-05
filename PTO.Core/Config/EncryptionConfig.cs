using PTO.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using PTO.Core.Extensions;

namespace PTO.Core.Config
{
    public class EncryptionConfig : IEncryptionConfig
    {
        private int _workFactor;
        private int _shiftFactor;
        private int _shiftOffset;
        private ShiftDirection _shiftDirection;

        private readonly IEncryptionConfig _template;

        public EncryptionConfig(XPathNavigator nav, IEncryptionConfig template)
        {
            _template = template;

            if (_template != null)
            {
                _workFactor = _template.WorkFactor;
                _shiftFactor = _template.ShiftFactor;
                _shiftOffset = _template.ShiftOffset;
                _shiftDirection = _template.ShiftDirection;
            }

            SetWorkFactor(nav);
            SetShiftFactor(nav);
            SetShiftOffset(nav);
            SetShiftDirection(nav);
        }

        public int WorkFactor
        {
            get { return _workFactor; }
        }

        public int ShiftFactor
        {
            get { return _shiftFactor; }
        }

        public int ShiftOffset
        {
            get { return _shiftOffset; }
        }

        public ShiftDirection ShiftDirection
        {
            get { return _shiftDirection; }
        }

        private void SetWorkFactor(XPathNavigator nav)
        {
            var value = nav.GetAttribute("workFactor", string.Empty);

            if (value.HasValue())
                _workFactor = int.Parse(value);
        }

        private void SetShiftFactor(XPathNavigator nav)
        {
            var value = nav.GetAttribute("shiftFactor", string.Empty);

            if (value.HasValue())
                _shiftFactor = int.Parse(value);
        }

        private void SetShiftOffset(XPathNavigator nav)
        {
            var value = nav.GetAttribute("shiftOffset", string.Empty);

            if (value.HasValue())
                _shiftOffset = int.Parse(value);
        }

        private void SetShiftDirection(XPathNavigator nav)
        {
            var value = nav.GetAttribute("shiftDirection", string.Empty);

            if (value.HasValue())
                _shiftDirection = (ShiftDirection)Enum.Parse(typeof(ShiftDirection), value, true);
        }
    }
}
