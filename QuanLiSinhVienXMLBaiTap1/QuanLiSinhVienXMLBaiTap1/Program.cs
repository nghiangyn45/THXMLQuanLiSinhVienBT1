using System;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        string path = @"D:\xml\students.xml";

        // Tải file XML
        XDocument doc = XDocument.Load(path);
        var students = doc.Element("students")?.Elements("student");

        if (students == null)
        {
            Console.WriteLine("Khong tim thay du lieu sinh vien trong file.");
            return;
        }

        // Yêu cầu 1: Đọc và in ra thông tin tất cả sinh viên
        Console.WriteLine("=== 1. THONG TIN TAT CA SINH VIEN ===");
        foreach (var st in students)
        {
            string id = st.Attribute("id")?.Value;
            string name = st.Element("name")?.Value;
            string age = st.Element("age")?.Value;
            string email = st.Element("email")?.Value;
            string major = st.Element("major")?.Value;

            Console.WriteLine($"ID: {id} | Tên: {name} | Tuoi: {age} | Email: {email} | Chuyên ngành: {major}");
        }
        Console.WriteLine();

        // Yêu cầu 2: In ra tên của tất cả sinh viên
        Console.WriteLine("=== 2. TEN CUA TAT CA SINH VIEN ===");
        foreach (var st in students)
        {
            string name = st.Element("name")?.Value;
            Console.WriteLine($"- {name}");
        }
        Console.WriteLine();

        // Yêu cầu 3: Tìm sinh viên có id = "SV02" và in thông tin
        Console.WriteLine("=== 3. TIM SINH VIEN CO ID = 'SV02' ===");
        var sv02 = students.FirstOrDefault(s => s.Attribute("id")?.Value == "SV02");
        if (sv02 != null)
        {
            Console.WriteLine($"ID: {sv02.Attribute("id")?.Value}");
            Console.WriteLine($"Tên: {sv02.Element("name")?.Value}");
            Console.WriteLine($"Tuoi: {sv02.Element("age")?.Value}");
            Console.WriteLine($"Email: {sv02.Element("email")?.Value}");
            Console.WriteLine($"Chuyên ngành: {sv02.Element("major")?.Value}");
        }
        else
        {
            Console.WriteLine("Khong tim thay sinh vien co id la SV02.");
        }
        Console.WriteLine();

        // Yêu cầu 4: Đếm tổng số sinh viên
        Console.WriteLine("=== 4. TONG SO SINH VIEN ===");
        int totalStudents = students.Count();
        Console.WriteLine($"Tong so luong sinh vien: {totalStudents}");
        Console.WriteLine();

        // Yêu cầu 5: Tìm những sinh viên có age >= 20
        Console.WriteLine("=== 5. SINH VIEN CO TUOI >= 20 ===");
        var svAge20Plus = students.Where(s => int.Parse(s.Element("age")?.Value ?? "0") >= 20);
        foreach (var st in svAge20Plus)
        {
            string id = st.Attribute("id")?.Value;
            string name = st.Element("name")?.Value;
            string age = st.Element("age")?.Value;
            Console.WriteLine($"- ID: {id} | Tên: {name} | Tuoi: {age}");
        }
    }
}