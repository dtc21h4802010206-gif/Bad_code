
    // --- Service quản lý sinh viên ---
    public class StudentService
    {
        private List<Student> students = new List<Student>();

        public void AddStudent()
        {
            Console.Write("Nhập id: ");
            string id = Console.ReadLine();
            Console.Write("Nhập tên: ");
            string name = Console.ReadLine();
            Console.Write("Nhập tuổi: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Nhập GPA: ");
            double gpa = double.Parse(Console.ReadLine());

            students.Add(new Student { Id = id, Name = name, Age = age, GPA = gpa });
            Console.WriteLine("✅ Thêm sinh viên thành công!");
        }

        public void RemoveStudent()
        {
            Console.Write("Nhập id cần xóa: ");
            string id = Console.ReadLine();
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("✅ Đã xóa sinh viên.");
            }
            else Console.WriteLine("❌ Không tìm thấy sinh viên.");
        }

        public void UpdateStudent()
        {
            Console.Write("Nhập id cần cập nhật: ");
            string id = Console.ReadLine();
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                Console.Write("Tên mới: ");
                student.Name = Console.ReadLine();
                Console.Write("Tuổi mới: ");
                student.Age = int.Parse(Console.ReadLine());
                Console.Write("GPA mới: ");
                student.GPA = double.Parse(Console.ReadLine());
                Console.WriteLine("✅ Cập nhật thành công!");
            }
            else Console.WriteLine("❌ Không tìm thấy sinh viên.");
        }

        public void ShowAll()
        {
            if (students.Count == 0) Console.WriteLine("Danh sách rỗng.");
            foreach (var s in students) Console.WriteLine(s);
        }

        public void FindByName()
        {
            Console.Write("Nhập tên: ");
            string name = Console.ReadLine();
            var result = students.Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            foreach (var s in result) Console.WriteLine("🔎 " + s);
        }

        public void FindGoodStudents()
        {
            var good = students.Where(s => s.GPA > 8.0);
            foreach (var s in good) Console.WriteLine("🌟 Sinh viên giỏi: " + s);
        }

        public void SortByName()
        {
            students = students.OrderBy(s => s.Name).ToList();
            Console.WriteLine("📑 Đã sắp xếp theo tên.");
        }

        public void SortByGPA()
        {
            students = students.OrderByDescending(s => s.GPA).ToList();
            Console.WriteLine("📑 Đã sắp xếp theo GPA.");
        }
    }

    // --- Chương trình chính ---
    class Program
    {
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService();
            int menu = 0;
            while (menu != 99)
            {
                Console.WriteLine("============= MENU CHÍNH =============");
                Console.WriteLine("1. Quản lý Sinh viên");
                Console.WriteLine("99. Thoát");
                Console.Write("Nhập lựa chọn: ");
                menu = int.Parse(Console.ReadLine());

                if (menu == 1)
                {
                    int smenu = 0;
                    while (smenu != 9)
                    {
                        Console.WriteLine("--- QUẢN LÝ SINH VIÊN ---");
                        Console.WriteLine("1. Thêm SV");
                        Console.WriteLine("2. Xóa SV");
                        Console.WriteLine("3. Cập nhật SV");
                        Console.WriteLine("4. Hiển thị tất cả SV");
                        Console.WriteLine("5. Tìm SV theo tên");
                        Console.WriteLine("6. Tìm SV GPA > 8");
                        Console.WriteLine("7. Sắp xếp theo tên");
                        Console.WriteLine("8. Sắp xếp theo GPA");
                        Console.WriteLine("9. Quay lại");
                        Console.Write("Nhập lựa chọn: ");
                        smenu = int.Parse(Console.ReadLine());

                        switch (smenu)
                        {
                            case 1: studentService.AddStudent(); break;
                            case 2: studentService.RemoveStudent(); break;
                            case 3: studentService.UpdateStudent(); break;
                            case 4: studentService.ShowAll(); break;
                            case 5: studentService.FindByName(); break;
                            case 6: studentService.FindGoodStudents(); break;
                            case 7: studentService.SortByName(); break;
                            case 8: studentService.SortByGPA(); break;
                        }
                    }
                }
            }
        }
    }
}
