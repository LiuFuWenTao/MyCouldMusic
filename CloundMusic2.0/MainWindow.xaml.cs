using CloudMusic.CloudApi.IApi;
using CloundMusic2._0.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using WebApiClient;

namespace CloundMusic2._0
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpApiConfig httpApiConfig = new HttpApiConfig();
                httpApiConfig.HttpHost = new Uri("http://music.rexhuang.top/");
                var myWebApi = HttpApiClient.Create<IMusicCloundApi>(httpApiConfig);
                var s = await myWebApi.GetMusicTpye();
                MusicTpyeModel model = JsonConvert.DeserializeObject<MusicTpyeModel>(s);


            }
            catch (Exception ex)
            {

                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ////用MediaPlayer类进行播放
            //MediaPlayer player = new MediaPlayer();
            //player.Open(new Uri(Environment.CurrentDirectory + "\\music.mp3", UriKind.Relative));
            //VideoDrawing aVideoDrawing = new VideoDrawing();
            //aVideoDrawing.Rect = new Rect(0, 0, 100, 100);
            //aVideoDrawing.Player = player;

            //player.Play();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //用MediaElement控件进行播放
            McMediaElement.Source = new Uri(Environment.CurrentDirectory + "\\Music\\刷身份证登录页面倒计时卡死.mp4");
            McMediaElement.Play();
        }
    }
}
