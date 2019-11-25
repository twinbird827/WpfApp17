using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp17
{
    public class ComboboxItemModel : BindableBase
    {
        public ComboboxItemModel(string value, string display)
        {
            Group = null;
            Value = value;
            Display = display;
        }

        public ComboboxItemModel(int value, string display) : this(value.ToString(), display)
        {

        }

        /// <summary>
        /// 空のｺﾝﾎﾞﾎﾞｯｸｽ
        /// </summary>
        public static ComboboxItemModel Empty = new ComboboxItemModel("", "");

        /// <summary>
        /// ｸﾞﾙｰﾌﾟ
        /// </summary>
        public string Group
        {
            get { return _Group; }
            set { SetProperty(ref _Group, value); }
        }
        private string _Group = default(string);

        /// <summary>
        /// 内部値
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { SetProperty(ref _Value, value); }
        }
        private string _Value = default(string);

        /// <summary>
        /// 表示値
        /// </summary>
        public string Display
        {
            get { return _Display; }
            set { SetProperty(ref _Display, value); }
        }
        private string _Display = default(string);

        /// <summary>
        /// ﾊｯｼｭｺｰﾄﾞを取得します。
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (Value != null)
            {
                return Value.GetHashCode();
            }
            else
            {
                return base.GetHashCode();
            }
        }

        /// <summary>
        /// ｺﾝﾎﾞﾎﾞｯｸｽ値が等価であるか比較します。
        /// </summary>
        /// <param name="obj">対象ｺﾝﾎﾞﾎﾞｯｸｽ</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (Value != null && obj is ComboboxItemModel)
            {
                return Value.Equals(((ComboboxItemModel)obj).Value);
            }
            else
            {
                return base.Equals(obj);
            }
        }

    }
}
