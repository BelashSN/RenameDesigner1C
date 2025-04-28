using System;
using System.Drawing;
using System.Windows.Forms;
//-------------------
using System.Reflection;
using System.Management;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace _1CRenameDesigner
{
    public partial class FormMe : Form
    {
        #region Global variables
        // ======================================= разрешение закрытия окна
        private static bool ClosePossible = false;

        // ======================================= импорт функции обращения к чужому окну
        [DllImport("user32.dll")] public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
        #endregion

        #region Сonstructor
        // ======================================= Конструктор
        public FormMe()
        {
            InitializeComponent();
        }
        #endregion

        #region Events of form
        // ======================================= при первом открытии формы (значения по-умолчанию)
        private void FormMe_Load(object sender, EventArgs e)
        {
            this.Visible = false;       // - скрываем форму из видимости
            chkSkip.Checked = false;    // - не показывать пропуски по умолчанию
            chkRename.Checked = true;   // - показывать замены по умолчанию
            chkErrors.Checked = true;   // - показывать ошибки по умолчанию
        }
        
        // ======================================= скопировать текст в клипбоард по двойному клику на поле
        private void TextResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Clipboard.SetText(TextResult.Text);
            //-------------------   // - показать надпись о копировании лога в буфео обмена
            lblClickForCopy.Text = "Текст лога скопирован в буфер отмена...";
            lblClickForCopy.ForeColor = Color.Red;
            TimerCopyLog.Enabled = true;
        }
        
        // ======================================= стереть надпись о копировании лога в буфео обмена 
        private void TimerCopyLog_Tick(object sender, EventArgs e)
        {
            lblClickForCopy.Text = "Для копирования текста лога в буфер обмена - двойной клик мыши по полю лога ↓";
            lblClickForCopy.ForeColor = Color.Blue;
            TimerCopyLog.Enabled = false;
        }
       
        // ======================================= меню - показать скрытое окно
        private void toolStripMenuItemShow_Click(object sender, EventArgs e)
        {
            this.Visible = true;                        // - показать скрытую форму
            this.ShowInTaskbar = true;                  // - показать кнопку панели задач
            this.WindowState = FormWindowState.Normal;  // - восстановить положение формы
        }
        
        // ======================================= меню - скрыть окно из виду
        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;   // - свернуть форму
            this.ShowInTaskbar = false;                     // - скрыть кнопку панели задач
            this.Visible = false;                           // - скрыть форму из видимости
            TextResult.Text = "";                           // - очистить текст лога формы
        }
        
        // ======================================= меню - закрыть приложение
        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            ClosePossible = true;   // - разрешить закрытие формы
            Application.Exit();     // - выход из приложения
        }
        
        // ======================================= при закрытии - скрыть окно из виду
        private void FormMe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClosePossible) e.Cancel = true;        // - если закрытие запрещено - отменим действие
            toolStripMenuItemClose_Click(null, null);   // - вызов меню скрытия формы
        }
        
        // ======================================= вызов меню при клике левой кнопкой на иконке в трее
        private void NotifyIconMe_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { // - если кнопка мыши левая
                // - получить метод правой кнопки
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);    
                mi.Invoke(NotifyIconMe, null);  // - вызов метода правой кнопки - меню иконки в тре
            }
        }
        
        // ======================================= вывод результата в окно сообщений
        private void ShowTextResult(String strResult)
        {
            if (!this.Visible) return;  // - если форма скрыта - текст лога не выводится
            //-------------------
            TextResult.Text = "==========================    " // - заголовок лога со временем
                + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") 
                + "    ==========================\r\n"
                + strResult + "\r\n" + TextResult.Text;         // - текст лога под заголовком
        }
       
        // ======================================= поиск и переименование окон конфигуратора 1с по таймеру
        private void TimerMe_Tick(object sender, EventArgs e)
        {
            String strResult = "";  // - текущие данные лога для вывода в окно
            //-------------------   // - удалим сообщения о копировании текста
            if (this.Visible) { TextResult.Text = TextResult.Text.Replace("\r\n\r\n- Текст скопирован  *************\r\n\r\n", ""); }
            //-------------------   // - получим список процессов - запрос по параметрам
            ManagementObjectSearcher searcher
                = new ManagementObjectSearcher("root\\CIMV2", "SELECT CommandLine,ProcessId FROM Win32_Process WHERE CommandLine LIKE '%DESIGNER%' AND Name LIKE '%1cv8%'");
            //-------------------   // - перебор полученных результатов запроса
            foreach (ManagementObject queryObj in searcher.Get()) {
                String CaptionNew = "";                                 // - новый заголовок окна 1С
                String CaptionAdd = "║";                                // - имя базы из командной строки по умолчанию
                String topResult = "------------  ║  ------------";     // - шапка текущего резултата в лог
                //-------------------
                String strCommand = (String) queryObj["CommandLine"]; strCommand.Trim();                 // - получить командную строку процесса
                string[] MassCommand = strCommand.ToLower().Replace(".exe\"", ".exe\"║").Split('║');     // - разбить на имя ехе и строку параметров
                String strBottom = "\r\n- 1C комманда: " + MassCommand[MassCommand.Length - 1];          // - последняя строка массива - параметры, если они есть
                //-------------------
                Process Process1c = Process.GetProcessById(Convert.ToInt32(queryObj["ProcessId"]));      // - получим процесс виндовс по его ИД
                String CaptionOld = Process1c.MainWindowTitle.Trim();                                    // - запомним старый (существующий) заголовок окна
                IntPtr Main1cHWND = Process1c.MainWindowHandle;                                          // - запомним дескриптор окна процесса
                //-------------------
                MassCommand = strCommand.Replace(" /", "║/").Split('║');                 // - разбить командную строку на отдельные параметры по разделителям
                for (int i = 0; i < MassCommand.Length; i++) {                           // - перебираем полученные строки
                    if (MassCommand[i].IndexOf("/F") > 0) { 
                        CaptionAdd = MassCommand[i].Replace("/F", "") + "  "; break; }              // - имя базы для файловой версии
                    else if (MassCommand[i].IndexOf("/S") > 0) { 
                        CaptionAdd = MassCommand[i].Replace("/S", "") + "  "; break; }         // - имя базы для серверной версии
                    else if (MassCommand[i].IndexOf("/IBName") >= 0) { 
                        CaptionAdd = MassCommand[i].Replace("/IBName", "").Replace("\"", "") + "  "; break; }    // - имя базы из стартера 1С
                }
                //-------------------
                if (CaptionAdd == "║") {                                // --- Не нашли ключ для имени базы - запишем ошибку в лог (если разрешено)
                    if (chkErrors.Checked) strResult += 
                            topResult.Replace("║", "Не найден ключ (/F,/S/IBName)")  + strBottom + "\r\n- " + CaptionOld + "\r\n";  }
                else if (CaptionOld.IndexOf(CaptionAdd) >= 0) {         // --- существующий заголовок окна уже содержит имя базы - пропуск в лог (если разрешено)  
                    if (chkSkip.Checked) strResult += 
                            topResult.Replace("║", "Пропуск (переименовано ранее)") + strBottom + "\r\n- " + CaptionOld + "\r\n"; }
                else {                                                   // --- Создаем новый заголовок 1С: имя базы + старый заголовок
                    CaptionNew += CaptionAdd + CaptionOld;
                    SendMessage(Main1cHWND, 0x000C, 0, CaptionNew);     // --- пошлем сообщение окну о смене заголовка
                    //-------------------                               // --- сохраним строку о замене в лог  (если разрешено) 
                    if (chkRename.Checked) strResult += 
                            topResult.Replace("║", "Замена") + strBottom + "\r\n-  С: " + CaptionOld + "\r\n- На: " + CaptionNew + "\r\n";  }
            }
            //-------------------
            if (this.Visible) ShowTextResult(strResult);                // --- если форма не скрыта - вызовем вывод лога на форму
        }
        #endregion
    }
}
