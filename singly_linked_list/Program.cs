﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace single_linked_list
{
    class Node
    {
        public int noMhs;
        public string nama;
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
            Console.Write("\nMasukkan nomer Mahasiswa: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama Mahasiswa: ");
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

        public bool Search(int nim, ref Node previous, ref Node current)/*Method untuk mengecek apakah node yang dimaksud ada didalam list atau tidak*/
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
                Console.WriteLine("\nList kosong. \n");
            else
            {
                Console.WriteLine("\nData didalam list adalah: \n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.noMhs + " " + currentNode.nama + "\n");
                Console.WriteLine();
            }
        }

        public bool listEmpty()
        {
            if(START == null)
                return true;
            else
                return false;
        }
    }
    class program
    {
        static void Main(string[] args)
        {
        }
    }
}
