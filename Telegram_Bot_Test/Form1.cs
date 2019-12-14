using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;

namespace Telegram_Bot_Test
{
    public partial class Form1 : Form
    {
        //string text = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private string randomAnekdotPage = @"https://anekdot-z.ru/random-anekdot";

        /// <summary>
        /// Start bot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            string text = richTextBoxData.Text; // получаем содержимое текстового поля txtKey в переменную text
            if (backgroundWorkerProcess.IsBusy != true)
            {
                backgroundWorkerProcess.RunWorkerAsync(text);
            }
        }

        /// <summary>
        /// Bot's work process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void backgroundWorkerProcess_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var key = e.Argument as string; // получаем ключ из аргументов

            try
            {
                var webProxy = new WebProxy("198.199.91.20:3128",true);
                var Bot = new Telegram.Bot.TelegramBotClient(key,webProxy);
                await Bot.SetWebhookAsync(""); //USE VPN
                int offset = 0; // отступ по сообщениям
                while (true)
                {
                    var updates = await Bot.GetUpdatesAsync(offset);

                    foreach (var update in updates)
                    {
                        var message = update.Message;
     
                           /* 
                            * Test message
                            if (message.Text == "/saysomething")
                            {
                                // в ответ на команду /saysomething выводим сообщение
                                await Bot.SendTextMessageAsync(message.Chat.Id, "тест",
                                       replyToMessageId: message.MessageId);
                            }
                            */

                        if (message.Text == "/random")
                        {
                            string pageText = AnekdotParsing.LoadPage(randomAnekdotPage);
                            string[] data = AnekdotParsing.ParseData(pageText);

                            string reply = string.Empty;
                            foreach (string str in data)
                            {
                                reply += str + "\n";
                            }

                            await Bot.SendTextMessageAsync(message.Chat.Id, reply);
                        }
                        
                        offset = update.Id + 1;
                    }

                }
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }

        /// <summary>
        /// Test parsing method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAnekdot_Click(object sender, EventArgs e)
        {
            string pageText = AnekdotParsing.LoadPage(randomAnekdotPage);
            string[] data = AnekdotParsing.ParseData(pageText);

            richTextBoxData.Text = string.Empty;
            foreach (string str in data)
            {
                richTextBoxData.Text += str + "\n";
            }
        }
    }
}
