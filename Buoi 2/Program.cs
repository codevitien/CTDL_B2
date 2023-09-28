using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchTypes
{
    internal class Program
    {
        class IntArray
        {
            int[] arr;
            //Propeties
            public int[] Arr { get => arr; set => arr = value; }
            // Constructor
            // Constructor không đối số
            public IntArray() { }
            // Constructor có đối số n và tạo ngẫu nhiên n phần tử cho dãy arr
            public IntArray(int n)
            {
                // n là số phần tử của array ar
                arr = new int[n];
                // khai báo biến rd kiểu Random
                Random rd = new Random();
                for (int i = 0; i < n; i++)
                    arr[i] = rd.Next(0, 100);  // Tạo số ngẫu nhiên từ 0 -> 99
            }
            // Constructor có đối số là array b và copy b -> arr
            public IntArray(int[] b)
            {
                arr = new int[b.Length];
                arr = b;
            }
            // Constructor copy : Đối số là object obj
            public IntArray(IntArray obj)
            {
                arr = new int[obj.Arr.Length];
                arr = obj.Arr;
            }
            // Xuất dãy arr lên màn hình
            public void Output()
            {
                foreach (int i in arr)
                    Console.Write($"{i} ");
            }

            // Tìm kiếm tuần tự
            public int SequentialSearch(int x)
            {
                // Phần làm bài
                // Duyệt từng phần tử arr[i]của array arr
                for (int i = 0; i < arr.Length; i++)
                    //    Nếu arr = x, trả về vị trí i
                    if (arr[i] == x)
                        return i;
                // Trả về -1 (lúc này kết thúc duyệt nhưng không tìm thấy)
                return -1;
            }
            // Sắp xếp dãy tăng dần (như đã học ở môn KTLT)
            public void Sort()
            {
                // Phần làm bài
                for (int i = 1; i < arr.Length; i++)
                {
                    int pos;
                    int x = arr[i];
                    for (pos = i - 1; pos >= 0 && arr[pos] > x; pos--)
                        arr[pos + 1] = arr[pos];
                    arr[pos + 1] = x;
                }
            }
            // Tìm kiếm bằng phương pháp Nhị phân
            // Tìm x trong khoản từ left đến right trong dãy
            public int BinarySearch(int x)
            {
                // Sắp xếp dãy arr tăng dần
                Sort();
                // Đặt giá trị ban đầu cho 2 biến left = 0 và right = arr.Lenght – 1
                int left = 0;
                int right = arr.Length - 1;
                // Khai báo biến mid (int)
                int mid;
                // Lặp (khi left <= right)


                while (left <= right)
                {
                    mid = (left + right) / 2;
                    if (x == arr[mid])
                        return mid;
                    if (x < arr[mid])
                        right = mid - 1;
                    if (x > arr[mid])
                        left = mid + 1;
                }
                // return -1 (không tìm thấy)
                return -1;
            }
            // Phương thức (đệ qui) Tìm x trong khoản từ left đến right trong dãy (đọc thêm)
            public int BinarySearch_DQ(int x, int left, int right)
            {
                Sort();
                //left<=right là điều kiện tiếp tục tìm (gọi đệ qui)
                if (left <= right)
                {
                    int mid = (left + right) / 2;
                    // Nếu arr[mid] = x, trả về chỉ số và kết thúc.
                    if (arr[mid] == x)
                        return mid;
                    // Nếu arr[mid] > x, thực hiện tìm kiếm nửa trái của dãy
                    else if (arr[mid] > x)
                        return BinarySearch_DQ(x, left, mid - 1);
                    // Nếu arr[mid] < x, thực hiện tìm kiếm nửa phải của dãy
                    else if (arr[mid] < x)
                        return BinarySearch_DQ(x, mid + 1, right);
                }
                // Khi cận trái left > cận phải right
                //  không tìm thấy (điều kiện dừng của đệ qui)
                return -1;
            }
        }

        
        class Menu
        {
            string mtitle;   // Lưu tiêu đề menu
            string[] itemList;  // Lưu các mục chọn
            public string Mtitle { get => mtitle; set => mtitle = value; }
            public string[] ItemList { get => itemList; set => itemList = value; }
            public Menu()
            { }
            public void ShowMenu(string title, string[] itemS)
            {
                // Tạo các mục chọn
                mtitle = title;
                itemList = new string[itemS.Length]; itemList = itemS;
                // Chiều rộng của mẫu báo cáo
                int width = title.Length + 50;
                // Top
                Console.Write("┌");
                Console.Write(new string('─', width));
                Console.WriteLine("┐");
                // Tiêu đề cột
                Console.Write("│");
                Console.Write((new string(' ', 25)) + mtitle + (new string(' ', 25)));
                Console.WriteLine("│");
                // Bottom của dòng tiêu đề cột
                Console.Write("├");
                Console.Write(new string('─', width));
                Console.WriteLine("┤");
                // Các mục chọn
                for (int i = 0; i < ItemList.Length; i++)
                {
                    Console.Write("│");
                    Console.Write((new string(' ', 15)) + itemList[i]);
                    Console.WriteLine((new string(' ', width - (15 + itemList[i].Length))) + "│");
                }
                // Bottom của bảng
                Console.Write("└");
                Console.Write(new string('─', width));
                Console.WriteLine("┘");
            }
        }
        static void Main(string[] args)
        {
            {
                // Xuất text theo Unicode (có dấu tiếng Việt)
                Console.OutputEncoding = Encoding.Unicode;
                // Nhập text theo Unicode (có dấu tiếng Việt)
                Console.InputEncoding = Encoding.Unicode;

                /* Tạo menu */
                Menu menu = new Menu();
                string title = "THUẬT TOÁN TÌM KIẾM";   // Tiêu đề menu
                                                        // Danh sách các mục chọn
                string[] ms = { "1. Tạo dãy số ngẫu nhiên", "2. Xuất dãy lên màn hình",
                "3. Tìm kiếm Tuần tự", "4. Tìm kiếm nhị phân", "0. Thoát" };
                // Khai báo biến ds (dãy số)
                IntArray ds = new IntArray();
                int chon;
                do
                {
                    // Xuất menu
                    menu.ShowMenu(title, ms);
                    Console.Write("     Chọn : ");
                    chon = int.Parse(Console.ReadLine());
                    switch (chon)
                    {
                        case 1:
                            {
                                // Nhập số phần tử n = ?
                                Console.Write("Nhap so phan tu n: ");
                                int n = int.Parse(Console.ReadLine());
                                // Khởi tạo ds : ds = new IntArray(n)
                                ds = new IntArray(n);
                                break;
                            }
                        case 2:
                            {
                                // Xuất dãy số arr lên màn hình
                                ds.Output();
                                break;
                            }
                        case 3:
                            {
                                // Nhập số cần tìm : x = ?
                                Console.Write("Nhap so can tim: ");
                                int x = int.Parse(Console.ReadLine());
                                // Tìm kiếm nhị phân với biến : int vt = ds.SequentialSearch(x)
                                int vt = ds.SequentialSearch(x);
                                // Xuất lết quả theo giá trị vt
                                if (vt != -1)
                                    Console.WriteLine($"{x} nam o vi tri {vt}");
                                else
                                    Console.WriteLine("Khong tim thay");
                                break;
                            }
                        case 4:
                            {
                                // Nhập số cần tìm : x = ?
                                Console.Write("Nhap so can tim: ");
                                int x = int.Parse(Console.ReadLine());
                                // Tìm kiếm nhị phân với biến : int vt = ds.BinarySearch(x)
                                int vt = ds.BinarySearch(x);
                                // Xuất lết quả theo giá trị vt
                                if (vt != -1)
                                    Console.WriteLine($"{x} nam o vi tri {vt}");
                                else
                                    Console.WriteLine("Khong tim thay");
                                break;
                            }
                    }
                    Console.WriteLine(" Nhấn một phím bất kỳ");
                    Console.ReadKey();
                    Console.Clear();
                } while (chon != 0);
            }
        }
    }
}
