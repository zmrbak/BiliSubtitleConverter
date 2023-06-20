using System.Diagnostics;
using System.Text.Json;
using System.Text;

namespace BiliSubtitleConverter
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            if (args.Length == 0 || File.Exists(args[0]) == false)
            {
                await Console.Out.WriteLineAsync("请添加下载的Bilibili视频字幕文件(Json)作为参数！");
                Console.ReadKey();
                return;
            }
            StringBuilder sb = new StringBuilder();

            var str = File.ReadAllText(args[0]);
            var a = JsonSerializer.Deserialize<Speech[]>(str);
            foreach (var item in a!)
            {
                sb.AppendLine(item.content);
            }
            File.WriteAllText("data.txt", sb.ToString());
            Process.Start("notepad.exe", "data.txt");
        }
    }
    public class Speech
    {
        public float from { get; set; }
        public float to { get; set; }
        public int sid { get; set; }
        public int location { get; set; }
        public string? content { get; set; }
    }
}