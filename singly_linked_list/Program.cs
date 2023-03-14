using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace single_linked_list
{
    class Node/*Main class*/
    {
        public int noMhs;/*Menggunakan integer karena untuk nomor mahasiswa*/
        public string nama;/*Memakai string untuk mengisi data nama*/
        public Node next;
    }

    class List
    {
        Node START;
        public List()
        {
            START =  null;
        }

        public void addNode()/* method untuk menambahkan sebuah Node kedalam list*/
        {
            int nim;
            string nm;
            Console.Write("\nMasukkan nomer Mahasiswa: ");/*Code untuk meng-input nomer mahasiswa*/
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama Mahasiswa: ");/*Code untuk meng-input nama mahasiswa*/
            nm = Console.ReadLine();
            Node nodeBaru =  new Node();
            nodeBaru.noMhs = nim;
            nodeBaru.nama = nm;

            if(START == null || nim <= START.noMhs)/*Node ditambahkan sebagai node pertama*/
            {
                if((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\nNomer Mahasiswa sama tidak diijinkan\n");
                    return;
                }
                nodeBaru.next = START;
                START = nodeBaru;
                return;
            }

            /*Menemukan lokasi node baru didalam list*/
            Node previous, current;
            previous = START;
            current = START;

            while((current != null) && (nim >= current.noMhs))
            {
                if(nim == current.noMhs)
                {
                    Console.WriteLine("\nNomer Mahasiswa sama tidak diijinkan\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            /*Node baru akan ditempatkan diantara previous dan current*/

            nodeBaru.next = current;
            previous.next = nodeBaru;
        }

        public bool delNode(int nim)/*Method untuk menghapus node tertentu didalam list */
        {
            Node previous, current;
            previous = current = null;
            if(Search(nim, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }

        public bool Search(int nim, ref Node previous, ref Node current)/*Method untuk mengecek apakah 
        node yang dimaksud ada didalam list atau tidak*/
        {
            previous = START;
            current = START;

            while((current != null) && (nim != current.noMhs))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);
        }

        public void traverse() /*Method untuk mengunjungi dan membaca isi list*/
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong. \n");/*Jika program mengunjungi list kosong, maka akan muncul kalimat "List kosong."*/
            else
            {
                Console.WriteLine("\nData didalam list adalah: \n");/*Jika program mendapati list yang ada isinya, maka menampilkan isi list*/
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.noMhs + " " + currentNode.nama + "\n");
                Console.WriteLine();
            }
        }

        public bool listEmpty()/*Method yang bertujuan jika node itu kosong*/
        {
            if(START == null)
                return true;
            else
                return false;
        }
        class program /*Kelas untuk menjalankan program*/
        {
            static void Main(string[] args)
            {
                List obj = new List();
                while (true)
                {
                    try
                    {
                        /*Menu yang program tampilkan untuk dipilih*/
                        Console.WriteLine("\nMenu\n");
                        Console.WriteLine("1. Menambah data kedalam list");
                        Console.WriteLine("2. Menghapus data dari dalam list");
                        Console.WriteLine("3. Melihat semua data didalam list");
                        Console.WriteLine("4. Mencari sebuah data didalam list");
                        Console.WriteLine("5. Exit");
                        Console.WriteLine("\nMasukkan pilihan anda (1-5): ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':/*Jika memilih opsi 1 maka akan dialihkan untuk menambahkan data dalam list*/
                                {
                                    obj.addNode();
                                }
                                break;
                            case '2':/*Jika memilih 2, maka akan dialihkan untuk menghapus data yang ada dalam list*/
                                {
                                    if (obj.listEmpty())
                                    {
                                        Console.WriteLine("\nList kosong");
                                        break;
                                    }
                                    Console.Write("\nMasukkan nomor mahasiswa yang akan dihapus: ");
                                    int nim = Convert.ToInt32(Console.ReadLine());
                                    if (obj.delNode(nim) == false)
                                        Console.WriteLine("\nData tidak ditemukan.");
                                    else
                                        Console.WriteLine("Data dengan nomor Mahasiswa " + nim + " dihapus");
                                }
                                break ;
                            case '3':/*Jika meilih 3, maka program akan menampilkan data yang ada di dalam list*/
                                {
                                    obj.traverse();
                                }
                                break;
                            case '4':/*Case untuk mencari data di dalam list*/
                                {
                                    if(obj.listEmpty() == true)
                                    {
                                        Console.WriteLine("\nList kosong");
                                        break ;
                                    }
                                    Node previous, current;
                                    previous = current = null;
                                    Console.Write("\nMasukkan nomor mahasiswa yang akan dicari: ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref previous, ref current) == false)
                                        Console.WriteLine("\nData tidak ditemukan.");
                                    else
                                    {
                                        Console.WriteLine("\nData ketemu");
                                        Console.WriteLine("\nNomor Mahasiswa: " + current.noMhs);
                                        Console.WriteLine("\nNama Mahasiswa: " + current.nama);
                                    }
                                }
                                break;
                            case '5':
                                return;
                            default:
                                {
                                    Console.WriteLine("\nPilihan tidak valid");/*Jika user salah meng-input data, maka program akan menampikan ini*/
                                    break;
                                }
                        }
                    }
                    catch(Exception e)/*Agar error tidak diketahui jika tidak dilihat.*/
                    {
                        Console.WriteLine("\nCheck nilai yang anda masukkan.");
                    }
                }
            }
        }
    }
   
}
