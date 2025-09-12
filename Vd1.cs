import java.util.*;

class Student {
    String id;
    String name;
    int age;
    double gpa;

    Student(String id, String name, int age, double gpa) {
        this.id = id;
        this.name = name;
        this.age = age;
        this.gpa = gpa;
    }

    @Override
    public String toString() {
        return String.format("ID:%s | Name:%s | Age:%d | GPA:%.2f", id, name, age, gpa);
    }
}

class Teacher {
    String id;
    String name;
    String major;

    Teacher(String id, String name, String major) {
        this.id = id;
        this.name = name;
        this.major = major;
    }

    @Override
    public String toString() {
        return String.format("ID:%s | Name:%s | Major:%s", id, name, major);
    }
}

class Course {
    String id;
    String name;
    int credits;

    Course(String id, String name, int credits) {
        this.id = id;
        this.name = name;
        this.credits = credits;
    }

    @Override
    public String toString() {
        return String.format("ID:%s | Name:%s | Credits:%d", id, name, credits);
    }
}

class Enrollment {
    String studentId;
    String courseId;

    Enrollment(String studentId, String courseId) {
        this.studentId = studentId;
        this.courseId = courseId;
    }

    @Override
    public String toString() {
        return String.format("Student:%s | Course:%s", studentId, courseId);
    }
}

class Grade {
    String studentId;
    String courseId;
    double score;

    Grade(String studentId, String courseId, double score) {
        this.studentId = studentId;
        this.courseId = courseId;
        this.score = score;
    }

    @Override
    public String toString() {
        return String.format("Student:%s | Course:%s | Score:%.2f", studentId, courseId, score);
    }
}

public class CleanSchoolProgram {
    private static final Scanner sc = new Scanner(System.in);

    private static final List<Student> students = new ArrayList<>();
    private static final List<Teacher> teachers = new ArrayList<>();
    private static final List<Course> courses = new ArrayList<>();
    private static final List<Enrollment> enrollments = new ArrayList<>();
    private static final List<Grade> grades = new ArrayList<>();

    public static void main(String[] args) {
        int choice;
        do {
            System.out.println("\n===== MENU CHINH =====");
            System.out.println("1. Quan ly Sinh vien");
            System.out.println("2. Quan ly Giao vien");
            System.out.println("3. Quan ly Mon hoc");
            System.out.println("4. Quan ly Dang ky hoc");
            System.out.println("5. Quan ly Diem");
            System.out.println("6. Bao cao tong hop");
            System.out.println("0. Thoat");
            System.out.print("Nhap lua chon: ");
            choice = sc.nextInt();
            sc.nextLine();

            switch (choice) {
                case 1 -> manageStudents();
                case 2 -> manageTeachers();
                case 3 -> manageCourses();
                case 4 -> manageEnrollments();
                case 5 -> manageGrades();
                case 6 -> report();
                case 0 -> System.out.println("Thoat chuong trinh.");
                default -> System.out.println("Lua chon khong hop le!");
            }
        } while (choice != 0);
    }

    // ====================== STUDENTS ======================
    private static void manageStudents() {
        int c;
        do {
            System.out.println("\n--- QUAN LY SINH VIEN ---");
            System.out.println("1. Them SV");
            System.out.println("2. Xoa SV");
            System.out.println("3. Cap nhat SV");
            System.out.println("4. Hien thi tat ca");
            System.out.println("0. Quay lai");
            System.out.print("Chon: ");
            c = sc.nextInt(); sc.nextLine();

            switch (c) {
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
            }
        } while (c != 0);
    }

    // ====================== TEACHERS ======================
    private static void manageTeachers() {
        int c;
        do {
            System.out.println("\n--- QUAN LY GIAO VIEN ---");
            System.out.println("1. Them GV");
            System.out.println("2. Xoa GV");
            System.out.println("3. Cap nhat GV");
            System.out.println("4. Hien thi tat ca");
            System.out.println("0. Quay lai");
            c = sc.nextInt(); sc.nextLine();

            switch (c) {
                case 1 -> {
                    System.out.print("ID: "); String id = sc.nextLine();
                    System.out.print("Ten: "); String name = sc.nextLine();
                    System.out.print("Chuyen mon: "); String major = sc.nextLine();
                    teachers.add(new Teacher(id, name, major));
                }
                case 2 -> {
                    System.out.print("Nhap ID can xoa: "); String id = sc.nextLine();
                    teachers.removeIf(t -> t.id.equals(id));
                }
                case 3 -> {
                    System.out.print("Nhap ID cap nhat: "); String id = sc.nextLine();
                    for (Teacher t : teachers) {
                        if (t.id.equals(id)) {
                            System.out.print("Ten moi: "); t.name = sc.nextLine();
                            System.out.print("Chuyen mon moi: "); t.major = sc.nextLine();
                        }
                    }
                }
                case 4 -> teachers.forEach(System.out::println);
            }
        } while (c != 0);
    }

    // ====================== COURSES ======================
    private static void manageCourses() {
        int c;
        do {
            System.out.println("\n--- QUAN LY MON HOC ---");
            System.out.println("1. Them MH");
            System.out.println("2. Xoa MH");
            System.out.println("3. Cap nhat MH");
            System.out.println("4. Hien thi tat ca");
            System.out.println("0. Quay lai");
            c = sc.nextInt(); sc.nextLine();

            switch (c) {
                case 1 -> {
                    System.out.print("ID: "); String id = sc.nextLine();
                    System.out.print("Ten: "); String name = sc.nextLine();
                    System.out.print("So tin chi: "); int tc = sc.nextInt(); sc.nextLine();
                    courses.add(new Course(id, name, tc));
                }
                case 2 -> {
                    System.out.print("Nhap ID can xoa: "); String id = sc.nextLine();
                    courses.removeIf(cou -> cou.id.equals(id));
                }
                case 3 -> {
                    System.out.print("Nhap ID cap nhat: "); String id = sc.nextLine();
                    for (Course cou : courses) {
                        if (cou.id.equals(id)) {
                            System.out.print("Ten moi: "); cou.name = sc.nextLine();
                            System.out.print("So tin chi moi: "); cou.credits = sc.nextInt(); sc.nextLine();
                        }
                    }
                }
                case 4 -> courses.forEach(System.out::println);
            }
        } while (c != 0);
    }

    // ====================== ENROLLMENTS ======================
    private static void manageEnrollments() {
        int c;
        do {
            System.out.println("\n--- QUAN LY DANG KY ---");
            System.out.println("1. Dang ky MH");
            System.out.println("2. Huy dang ky");
            System.out.println("3. Hien thi tat ca");
            System.out.println("0. Quay lai");
            c = sc.nextInt(); sc.nextLine();

            switch (c) {
                case 1 -> {
                    System.out.print("ID SV: "); String sid = sc.nextLine();
                    System.out.print("ID MH: "); String cid = sc.nextLine();
                    enrollments.add(new Enrollment(sid, cid));
                }
                case 2 -> {
                    System.out.print("ID SV: "); String sid = sc.nextLine();
                    System.out.print("ID MH: "); String cid = sc.nextLine();
                    enrollments.removeIf(e -> e.studentId.equals(sid) && e.courseId.equals(cid));
                }
                case 3 -> enrollments.forEach(System.out::println);
            }
        } while (c != 0);
    }

    // ====================== GRADES ======================
    private static void manageGrades() {
        int c;
        do {
            System.out.println("\n--- QUAN LY DIEM ---");
            System.out.println("1. Nhap diem");
            System.out.println("2. Cap nhat diem");
            System.out.println("3. Hien thi tat ca");
            System.out.println("0. Quay lai");
            c = sc.nextInt(); sc.nextLine();

            switch (c) {
                case 1 -> {
                    System.out.print("ID SV: "); String sid = sc.nextLine();
                    System.out.print("ID MH: "); String cid = sc.nextLine();
                    System.out.print("Diem: "); double score = sc.nextDouble(); sc.nextLine();
                    grades.add(new Grade(sid, cid, score));
                }
                case 2 -> {
                    System.out.print("ID SV: "); String sid = sc.nextLine();
                    System.out.print("ID MH: "); String cid = sc.nextLine();
                    for (Grade g : grades) {
                        if (g.studentId.equals(sid) && g.courseId.equals(cid)) {
                            System.out.print("Diem moi: "); g.score = sc.nextDouble(); sc.nextLine();
                        }
                    }
                }
                case 3 -> grades.forEach(System.out::println);
            }
        } while (c != 0);
    }

    // ====================== REPORT ======================
    private static void report() {
        System.out.println("\n=== BAO CAO ===");
        for (Student s : students) {
            System.out.println("Sinh vien: " + s.name);
            for (Enrollment e : enrollments) {
                if (e.studentId.equals(s.id)) {
                    for (Course c : courses) {
                        if (c.id.equals(e.courseId)) {
                            System.out.print(" - Mon hoc: " + c.name);
                            grades.stream()
                                    .filter(g -> g.studentId.equals(s.id) && g.courseId.equals(c.id))
                                    .findFirst()
                                    .ifPresent(g -> System.out.print(" | Diem: " + g.score));
                            System.out.println();
                        }
                    }
                }
            }
        }
    }
}
