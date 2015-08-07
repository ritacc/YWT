using System;
using System.Collections.Generic;
using System.Text;

namespace SystemModle
{
    public class ListItem
    {
        private string _Text;
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        private string _Value;
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public ListItem()
        {

        }

        public ListItem(string text)
        {
            _Text = _Value = text;
        }

        public ListItem(string text, string value)
        {
            _Text = text;
            _Value = value;
        }

        public override string ToString()
        {
            return _Text;
        }

        //public override bool Equals(object obj)
        //{
        //    return _Text.Equals((obj as ListItem).Value);
        //}
    }
}
