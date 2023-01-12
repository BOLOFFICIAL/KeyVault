
/*==========================================================
╔═╗╔══╗ ╔════╗ ╔╗   ╔╗ ╔╗   ╔╗ ╔═════╗ ╔═╗ ╔═╗ ╔═╗   ╔═════╗ 
║ ║║ ╔╝ ║ ╔══╝ ║╚╗ ╔╝║ ║╚╗ ╔╝║ ║ ╔═╗ ║ ║ ║ ║ ║ ║ ║   ║╔╗ ╔╗║ 
║ ╚╝ ║  ║ ╚══╗ ╚╗╚═╝╔╝ ╚╗║ ║╔╝ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║   ╚╝║ ║╚╝ 
║ ╔╗ ║  ║ ╔══╝  ╚╗ ╔╝   ║╚═╝║  ║ ╚═╝ ║ ║ ║ ║ ║ ║ ║ ╔═╗ ║ ║   
║ ║║ ╚╗ ║ ╚══╗   ║ ║    ╚╗ ╔╝  ║ ╔═╗ ║ ║ ╚═╝ ║ ║ ╚═╝ ║ ║ ║   
╚═╝╚══╝ ╚════╝   ╚═╝     ╚═╝   ╚═╝ ╚═╝ ╚═════╝ ╚═════╝ ╚═╝   
====================== KEYVAULT v1.0.0 =====================
                  property of bolofficial 
                        on 30.08.2022 
==========================================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyVault.Properties;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace KeyVault
{
    public partial class Form_KeyVault : Form
    {
        string program_password = "";
        string password_titles = "";
        string password_logins = "";
        string password_passwords = "";
        string password_sites = "";
        string password_comments = "";

        Button last_button = null;
        Panel last_panel = null;
        Passwords selected_item = null;

        public Form_KeyVault()                                                                              // Главная функция                                      (ok)
        {
            InitializeComponent();
            All_Fill();
            UnVisible();
            InitializePassword();
            Start_Window();
        }
        
        private void EmptyTextBox()                                                                         // Очистка текста при создании или изменении элемента   (ok)
        {
            textBox_title_password.Text = "";
            textBox_login_password.Text = "";
            textBox_password_password.Text = "";
            textBox_site_password.Text = "";
            textBox_comment_password.Text = "";
        }
        
        private void InitializePassword()                                                                   // Инициализация элементов                              (ok)
        {
            program_password = Settings.Default["password"].ToString();
            password_titles = Settings.Default["Passwordtitles"].ToString();
            password_logins = Settings.Default["Passwordlogins"].ToString();
            password_passwords = Settings.Default["Passwordpasswords"].ToString();
            password_sites = Settings.Default["Passwordsites"].ToString();
            password_comments = Settings.Default["Passwordcomments"].ToString();

            if (password_titles.Length>0) 
            {
                var array_titles = password_titles.Split('~');
                var array_logins = password_logins.Split('~');
                var array_passwords = password_passwords.Split('~');
                var array_sites = password_sites.Split('~');
                var array_comments = password_comments.Split('~');
                for (int i = 0; i < array_titles.Length; i++)
                {
                    if (array_titles[i].Length > 0)
                    {
                        Passwords password = new Passwords(
                        array_titles[i],
                        array_logins[i],
                        array_passwords[i],
                        array_sites[i],
                        array_comments[i]);
                        listBox_passwords.Items.Add(password);
                    }
                }
            }
        }
        
        private void UnVisible()                                                                            // Выключение всех панелей                              (ok)
        {
            panel_about.Visible = false;
            panel_edit_password.Visible = false;
            panel_functions.Visible = false;
            panel_main_program.Visible = false;
            panel_make_password.Visible = false;
            panel_passwords.Visible = false;
            panel_password_entry.Visible = false;
            panel_action.Visible = true;
            panel_add_pass.Visible = false;
        }
        
        private void All_Fill()                                                                             // Перевод всех панелей в полноэкранный режим           (ok)
        {
            panel_about.Dock = DockStyle.Fill;
            panel_edit_password.Dock = DockStyle.Fill;
            panel_functions.Dock = DockStyle.Fill;
            panel_main_program.Dock = DockStyle.Fill;
            panel_make_password.Dock = DockStyle.Fill;
            panel_passwords.Dock = DockStyle.Fill;
            panel_password_entry.Dock = DockStyle.Fill;
            panel_add_pass.Dock = DockStyle.Fill;
        }
        
        private void Start_Window()                                                                         // Стартовое окно в зависимости от наличия пароля       (ok)
        {
            if (program_password.Length > 0)
            { 
                panel_password_entry.Visible = true; 
            }
            else
            {
                panel_main_program.Visible = true;
                panel_action.Visible = true;
            }
        }
        
        private void button_functions_Click(object sender, EventArgs e)                                     // кнопка функций программы                             (ok)
        {
            Button_color(button_functions);
            Active_Panel(panel_functions);
        }
        
        private void button_make_password_Click(object sender, EventArgs e)                                 // кнопка создания или изменения пароля программы       (ok)
        {
            
            if (program_password.Length == 0)
            {
                Active_Panel(panel_make_password);
            }
            else
            {
                Active_Panel(panel_edit_password);
            }
        }
        
        private void button_password_entry_Click(object sender, EventArgs e)                                // Ввод пароля на экране блокировки                     (ok)
        {
            if (textBox_password_entry.Text == program_password)
            {
                panel_password_entry.Visible = false;
                panel_main_program.Visible = true;
            }
            else 
            {
                MakeMessage("Неправильный пароль","Экран блокировки",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            textBox_password_entry.Text = "";
        }
        
        private void Update_Password(string password = "")                                                  // Обновление пароля                                    (ok)
        {
            Settings.Default["password"] = password;
            Settings.Default.Save();
            program_password = Settings.Default["password"].ToString();
        }
        
        private void button_make_save_new_password_Click(object sender, EventArgs e)                        // Создание пароля программы                            (ok)
        {
            if (textBox_make_new_password.Text == textBox_make_repeat_new_password.Text)
            {
                Update_Password(textBox_make_repeat_new_password.Text);
                MakeMessage("Пароль успешно установлен", "Создание пароля", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Active_Panel(panel_functions);
            }
            else 
            {
                MakeMessage("Пароли должны быть одинаковыми","Создание пароля",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            textBox_make_new_password.Text = "";
            textBox_make_repeat_new_password.Text = "";
        }
        
        private void button_edit_save_new_password_Click(object sender, EventArgs e)                        // Изменение пароля программы                           (ok)
        {
            if (textBox_edit_old_password.Text == program_password)
            {
                if (textBox_edit_new_password.Text == textBox_edit_repeat_new_password.Text)
                {
                    Update_Password(textBox_edit_repeat_new_password.Text);
                    MakeMessage("Пароль успешно изменен", "Изменение пароля", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Active_Panel(panel_functions);
                }
                else 
                {
                    MakeMessage("Пароли должны быть одинаковыми", "Изменение пароля", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MakeMessage("Неправльный старый пароль", "Изменение пароля", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox_edit_old_password.Text = "";
            textBox_edit_new_password.Text = "";
            textBox_edit_repeat_new_password.Text = "";
        }
        
        private void button_passwords_Click(object sender, EventArgs e)                                     // Переход к панеле пароли                              (ok)
        {
            Button_color(button_passwords);
            Active_Panel(panel_passwords);
        }
        
        private void listBox_passwords_SelectedIndexChanged(object sender, EventArgs e)                     // Вывод данных выбранного элемента                     (ok)
        {
            int index = listBox_passwords.SelectedIndex;
            selected_item = (Passwords)listBox_passwords.SelectedItem;
            if (index > -1 && index < listBox_passwords.Items.Count)
            {
                textBox_title_password.Text = selected_item.title;
                textBox_login_password.Text = selected_item.login;
                textBox_password_password.Text = selected_item.passwords;
                textBox_site_password.Text = selected_item.site;
                textBox_comment_password.Text = selected_item.comment;
            }

        }
        
        private void button_delete_password_Click(object sender, EventArgs e)                               // Удаление выбранного элемента                         (ok)
        {
            EmptyTextBox();
            listBox_passwords.Items.Remove(listBox_passwords.SelectedItem);
            Save_date();
        }
        
        private void button_add_password_Click(object sender, EventArgs e)                                  // Добавление нового элемента                           (ok)
        {
            selected_item = null;
            Add_Edit("Добавить");
        }
        
        private void button_edit_password_Click(object sender, EventArgs e)                                 // Изменение выбранного элемента                        (ok)
        {
            if (selected_item != null)
            {
                Add_Edit("Изменить", selected_item);
            }
        }
        
        private void Add_Edit(string button_text,Passwords SelectedItem = null)                             // Вид панели при нажатиикнопки Изменить или Добавить   (ok)
        {
            button_add_edit.Text = button_text;
            EmptyTextBox();
            Active_Panel(panel_add_pass);
            string title = "";
            string login = "";
            string password = "";
            string site = "";
            string comment = "";
            if (SelectedItem != null)
            {
                title = SelectedItem.title;
                login = SelectedItem.login;
                password = SelectedItem.passwords;
                site = SelectedItem.site;
                comment = SelectedItem.comment;
            }
            textBox_title_password_add_edit.Text = title;
            textBox_login_password_add_edit.Text = login;
            textBox_password_password_add_edit.Text = password;
            textBox_site_password_add_edit.Text = site;
            textBox_comment_password_add_edit.Text = comment;
        }
        
        private void button_delete_all_Click(object sender, EventArgs e)                                    // Кнопка Удаления всех паролей                         (ok)
        {
            Reset();
        }
        
        private void button_reset_password_Click(object sender, EventArgs e)                                // Сброс паролей с экрана блокировки                    (ok)
        {
            Reset();
            Start_Window();
        }
        
        private void Reset()                                                                                // Удаление всех паролей                                (ok)
        {
            if (listBox_passwords.Items.Count + program_password.Length != 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить все пароли?", "Полное удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBox_passwords.Items.Clear();
                    Update_Password();
                    MakeMessage("Все пароли успешно удалены", "Полное удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Save_date();
                }
            }
            else 
            {
                MakeMessage("Нет доступных паролей для удаления", "Полное удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            EmptyTextBox();
        }
        
        private void button_add_edit_Click(object sender, EventArgs e)                                      // Изменение или создание пароля                        (ok)
        {
            string title = selected_item != null ? "Изменение элемента" : "Добавление элемента";
            if (Check_Password(textBox_title_password_add_edit.Text,
                textBox_login_password_add_edit.Text,
                textBox_password_password_add_edit.Text,
                textBox_site_password_add_edit.Text,
                textBox_comment_password_add_edit.Text))
            {
                if (textBox_title_password_add_edit.Text.Length > 0)
                {
                    if (CheckText(
                        textBox_title_password_add_edit.Text +
                        textBox_login_password_add_edit.Text +
                        textBox_password_password_add_edit.Text +
                        textBox_site_password_add_edit.Text +
                        textBox_comment_password_add_edit.Text))
                    {
                        listBox_passwords.Items.Add(
                            new Passwords(
                                String_Value(textBox_title_password_add_edit.Text),
                                String_Value(textBox_login_password_add_edit.Text),
                                String_Value(textBox_password_password_add_edit.Text),
                                String_Value(textBox_site_password_add_edit.Text),
                                String_Value(textBox_comment_password_add_edit.Text)
                            ));
                        textBox_title_password_add_edit.Text = "";
                        textBox_login_password_add_edit.Text = "";
                        textBox_password_password_add_edit.Text = "";
                        textBox_site_password_add_edit.Text = "";
                        textBox_comment_password_add_edit.Text = "";
                        if (selected_item != null)
                        {
                            listBox_passwords.Items.Remove(selected_item);
                            MakeMessage("Элемент успешно изменен", "Изменение элемента", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Active_Panel(panel_passwords);
                        }
                        else
                        {
                            MakeMessage("Новый элемент успешно добавлен", "Добавление элемента", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        Save_date();
                    }
                }
                else
                {
                    MakeMessage("Элемент должен иметь название", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MakeMessage("Такой элемент уже присутствует", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bool CheckText(string text) // Проверка наличия специального символа (ok)
            {
                foreach(var symbol in text)
                {
                    if (symbol == '~') 
                    {
                        MakeMessage("Элемент не должен содержать символ ~ (тильда)", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                return true;
            }
            string String_Value(string test)                                                                // Устанавливает значение для строки при создании нового пароля (ok)
            {
                if (test.Length > 0&& test!=null) 
                {
                    return test;
                }
                return "";
            }
            bool Check_Password(string pass_title, string pass_login, string pass_password, string pass_site, string pass_comment)
            {
                foreach (Passwords password in listBox_passwords.Items) 
                {
                    if (password.title == pass_title)
                    {
                        if (password.login == pass_login) 
                        {
                            if (password.passwords == pass_password)
                            {
                                if (password.site == pass_site)
                                {
                                    if (password.comment == pass_comment)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
                return true;
            }
        }                       
        
        private void button_about_Click(object sender, EventArgs e)                                         // Открывает панель "о программе"                       (ok)
        {
            Button_color(button_about);
            Active_Panel(panel_about);
        }
        
        private void Button_color(Button button)                                                            // Устанавливает цвет кнопки при ее выборе              (ok)
        {
            if (last_button != null) 
            {
                last_button.BackColor = Color.FromArgb(201,101,103);
            }
            button.BackColor = Color.FromArgb(158,90,99);
            last_button = button;
        }
        
        private void Active_Panel(Panel panel)                                                              // Переключение активной панели                         (ok)
        {
            if (last_panel!=panel) 
            {
                if (last_panel != null) 
                {
                    last_panel.Visible = false;
                }
                panel.Visible = true;
                last_panel = panel;
            }
        }
        
        private void Save_date()                                                                            // Сохранение данных                                    (ok)
        {
            Thread save = new Thread(Save);
            save.Start();
            void Save() //Сохранение
            {
                password_titles = "";
                password_logins = "";
                password_passwords = "";
                password_sites = "";
                password_comments = "";

                foreach (Passwords el in listBox_passwords.Items)
                {
                    password_titles += el.title + "~";
                    password_logins += el.login + "~";
                    password_passwords += el.passwords + "~";
                    password_sites += el.site + "~";
                    password_comments += el.comment + "~";
                }

                Settings.Default["Passwordtitles"] = password_titles;
                Settings.Default["Passwordlogins"] = password_logins;
                Settings.Default["Passwordpasswords"] = password_passwords;
                Settings.Default["Passwordsites"] = password_sites;
                Settings.Default["Passwordcomments"] = password_comments;
                Settings.Default.Save();
            }
        }
        
        private void button_upload_password_Click(object sender, EventArgs e)                               // Вывод паролей в фаил                                 (ok)
        {
            string output = "";
            if (listBox_passwords.Items.Count > 0)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string way = saveFileDialog1.FileName;
                    if (File.Exists(way)) 
                    {
                        var fileinfo = new FileInfo(way);
                        if (fileinfo.Length > 0 && MessageBox.Show("Сохранить прежнее содержимое файла?", "Выгрузка паролей", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            output = File.ReadAllText(way);
                        }
                    }
                    Print_Date(" Пароли от " + DateTime.Now+" ");
                    Line();
                    output += New_Size("Название", Passwords.max_title + 1) + "|";
                    output += New_Size("Логин", Passwords.max_login + 2) + "|";
                    output += New_Size("Пароль", Passwords.max_passwords + 2) + "|";
                    output += New_Size("Место", Passwords.max_site + 2) + "|";
                    output += New_Size("Комментарий", Passwords.max_comment + 2) + "|";
                    output += "\n";
                    Line();
                    foreach (Passwords el in listBox_passwords.Items)
                    {
                        output += New_Size(el.title, Passwords.max_title) + " | ";
                        output += New_Size(el.login, Passwords.max_login) + " | ";
                        output += New_Size(el.passwords, Passwords.max_passwords) + " | ";
                        output += New_Size(el.site, Passwords.max_site) + " | ";
                        output += New_Size(el.comment, Passwords.max_comment) + " | ";
                        output += "\n";
                        Line();
                    }
                    output += "\n\n";
                    File.WriteAllText(way, output);
                    if (MessageBox.Show("Открыть созданный фаил?", "Выгрузка паролей", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(way);
                    }
                }
            }
            else 
            {
                MakeMessage("Нет доступных элементов для выгрузки", "Выгрузка паролей", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string New_Size(string text, int size, char ch = ' ') // Увеличение длины строки (ok)
            {
                while (text.Length < size)
                {
                    text += ch;
                }
                return text;
            }
            void Line() // Строка формата +----+ (ok)
            {
                output += New_Size("", Passwords.max_title + 1, '-') + "+";
                output += New_Size("", Passwords.max_login + 2, '-') + "+";
                output += New_Size("", Passwords.max_passwords + 2, '-') + "+";
                output += New_Size("", Passwords.max_site + 2, '-') + "+";
                output += New_Size("", Passwords.max_comment + 2, '-') + "+";
                output += "\n";
            }
            void Print_Date(string date) 
            {
                string temp_line = New_Size("", date.Length, '-');
                output += "+";
                output += temp_line;
                output += "+";
                output += "\n|" + date + "|\n";
                output += "+";
                output += temp_line;
                output += "+\n";
            }
        }
        
        private void MakeMessage(string text, string title, MessageBoxButtons button, MessageBoxIcon icon)  // Создание всплывающего окна                           (ok)
        {
            MessageBox.Show(text, title, button, icon);
        }

    }
}
