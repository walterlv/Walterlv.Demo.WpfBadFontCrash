using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Walterlv.Demo.AllFonts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Dispatcher.UnhandledException += Dispatcher_UnhandledException;
            ContentRendered += OnContentRendered;
        }

        private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Dispatcher.InvokeAsync(() =>
            {
                MessageBox.Show(e.Exception.ToString(), "UnhandledException");
            });
        }

        private void OnContentRendered(object sender, EventArgs e)
        {
            FontListBox.ItemsSource = GetInstalledFamilies();
        }

        /// <summary>
        /// 获取当前机器上的字体
        /// </summary>
        /// <returns></returns>
        internal static List<string> GetInstalledFamilies()
        {
            //无法获取到部分已安装字体，尝试用新的字体获取方案，需要在不同系统上充分验证，故暂时留着老的方案代码
            var familyNames = GetInstalledFontFamilies().Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).ToList();
            //familyNames.Add("ENFont");
            familyNames.AddRange(GetSystemFontFamilies());
            familyNames = familyNames.Distinct().ToList();
            familyNames.Sort();
            //如果当前区域为中文，中文字体在前，英文字体在后
            familyNames = FontFamiliesSortByZh(familyNames);

            return familyNames;
        }

        private static List<System.Drawing.FontFamily> GetInstalledFontFamilies()
        {
            var fc = new InstalledFontCollection();
            return fc.Families.ToList();
        }

        /// <summary>
        /// 字体列表排序，仅在当前系统为中文下进行排序
        /// </summary>
        /// <param name="familyNames"></param>
        /// <returns></returns>
        private static List<string> FontFamiliesSortByZh(List<string> familyNames)
        {
            if (CultureInfo.CurrentCulture.Name.StartsWith("zh"))
            {
                var index = familyNames.FindLastIndex(x => char.IsLower(x[0]) || char.IsUpper(x[0])) + 1;
                if (index < familyNames.Count)
                {
                    var tempNames = familyNames.Skip(index).ToList();
                    tempNames.AddRange(familyNames.Take(index));
                    familyNames = tempNames;
                }
            }

            return familyNames;
        }

        private static List<string> GetSystemFontFamilies()
        {
            // WPF 拿取区域字体
            var currentCulture = CultureInfo.CurrentUICulture;
            var defaultCulture = new CultureInfo("en-US");

            // 添加本地区域字体
            var familieNames = Fonts.SystemFontFamilies.Select(x => x.FamilyNames).Select(x => x.FirstOrDefault(k => Equals(k.Key.GetSpecificCulture(), currentCulture))).Where(x => x.Key != null).Select(x => x.Value).ToList();
            familieNames.Sort();

            // 添加默认区域字体
            if (!Equals(currentCulture, defaultCulture))
            {
                var defautfonts = Fonts.SystemFontFamilies.Select(x => x.FamilyNames).Where(x => x.Any(k => Equals(k.Key.GetSpecificCulture(), defaultCulture)) && x.All(k => !Equals(k.Key.GetSpecificCulture(), currentCulture))).Select(x => x.FirstOrDefault(k => Equals(k.Key.GetSpecificCulture(), defaultCulture))).Where(x => x.Key != null).Select(x => x.Value).ToList();
                defautfonts.Sort();
                familieNames.AddRange(defautfonts);
            }

            return familieNames.ToList();
        }
    }
}
