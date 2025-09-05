import java.util.*;

class Student {
    String id;
    String name;
    int age;
    double gpa;

    Student(String id, String name, int age, double gpa) {
        this.id = id; this.name = name; this.age = age; this.gpa = gpa;
    }

    @Override
    public String toString() {
        return id + " | " + name + " | " + age + " | " + gpa;
    }
}

public class CleanStudentProgram {
    static List<Student> students = new ArrayList<>();

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int choice;
        do {
            System.out.println("\n--- MENU ---");
            System.out.println("1. Them SV");
            System.out.println("2. Xoa SV");
            System.out.println("3. Cap nhat SV");
            System.out.println("4. Hien thi tat ca");
            System.out.println("5. Sap xep theo GPA");
            System.out.println("6. Thoat");
            System.out.print("Chon: ");
            choice = sc.nextInt(); sc.nextLine();

            switch (choice) {
                case 1 -> {
                    System.out.print("ID: "); String id = sc.nextLine();
                    System.out.print("Ten: "); String name = sc.nextLine();
                    System.out.print("Tuoi: "); int age = sc.nextInt();
                    System.out.print("GPA: "); double gpa = sc.nextDouble(); sc.nextLine();
                    students.add(new Student(id, name, age, gpa));
                }
                case 2 -> {
                    System.out.print("Nhap ID can xoa: "); String id = sc.nextLine();
                    students.removeIf(s -> s.id.equals(id));
                }
                case 3 -> {
                    System.out.print("Nhap ID cap nhat: "); String id = sc.nextLine();
                    for (Student s : students) {
                        if (s.id.equals(id)) {
                            System.out.print("Ten moi: "); s.name = sc.nextLine();
                            System.out.print("Tuoi moi: "); s.age = sc.nextInt();
                            System.out.print("GPA moi: "); s.gpa = sc.nextDouble(); sc.nextLine();
                        }
                    }
                }
                case 4 -> students.forEach(System.out::println);
                case 5 -> {
                    students.sort(Comparator.comparingDouble(s -> -s.gpa));
                    students.forEach(System.out::println);
                }
            }
        } while (choice != 6);
    }
}
