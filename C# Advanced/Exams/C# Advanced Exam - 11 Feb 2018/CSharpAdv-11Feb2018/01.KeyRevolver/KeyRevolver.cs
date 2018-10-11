using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.KeyRevolver
{
    class KeyRevolver
    {
        static Queue<int> locks;
        static Stack<int> bullets;
        static int gunBarrelSize;
        static Queue<int> barrel = new Queue<int>();

        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            gunBarrelSize = int.Parse(Console.ReadLine());
            bullets = new Stack<int>(Console.ReadLine().Split(new char[] { ' ' },
                                                   StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(int.Parse)
                                                   .ToArray());
            locks = new Queue<int>(Console.ReadLine().Split(new char[] { ' ' },
                                                 StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(int.Parse)
                                                  .ToArray());

            int intelligence = int.Parse(Console.ReadLine());
            int bulletsUsed = 0;


            if (barrel.Count == 0)
            {
                Reload();
            }


            while (locks.Count > 0)
            {
                int currentBullet = barrel.Dequeue();
                int currentLock = locks.Peek();

                bulletsUsed++;
                if (currentBullet > currentLock)
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }

                if (barrel.Count == 0)
                {
                    if (bullets.Count == 0)
                    {
                        break;
                    }
                    Reload();
                    Console.WriteLine("Reloading!");
                }
            }
            
            if (locks.Count == 0)
            {
                int earned = intelligence - (bulletPrice * bulletsUsed);
                Console.WriteLine($"{bullets.Count + barrel.Count} bullets left. Earned ${earned}");
                return;
            }

            if (bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                return;
            }


        }

        static void Reload()
        {
            int bulletsLoaded = 0;

            while (bulletsLoaded < gunBarrelSize && bullets.Count > 0)
            {
                barrel.Enqueue(bullets.Pop());
                bulletsLoaded++;
            }
        }
    }
}