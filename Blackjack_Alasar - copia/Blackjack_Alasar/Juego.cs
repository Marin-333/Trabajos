using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Blackjack_Alasar;

    namespace Blackjack_Alasar
    {
        internal class Juego
        {
            private Random rand = new Random();
            public void IniciarJuego()
            {
                DecisionJ();
                JugarSolo();
                JugarConAmigos();
            }
            private void DecisionJ() 
            {
                {
                    Console.WriteLine("¡Bienvenido al Blackjack con dados!");
                    Console.WriteLine("Selecciona el modo de juego:");
                    Console.WriteLine("1. Jugar solo (contra la maquina)");
                    Console.WriteLine("2. Jugar con amigos (todos contra la maquina)");
                    int modoJuego = int.Parse(Console.ReadLine());

                    if (modoJuego == 1)
                    {
                        JugarSolo();
                    }
                    else if (modoJuego == 2)
                    {
                        JugarConAmigos();
                    }
                    else
                    {
                        Console.WriteLine("Opción no valida. Saliendo del juego...");
                    }
                }

            }
            private void JugarSolo()
            {
                int puntajeJugador = 0;
                int puntajeMaquina = 0;

                Console.WriteLine("\nModo: Jugar solo (contra la máquina)");

                // Lanzamiento inicial del jugador
                int dado1 = rand.Next(1, 7);
                int dado2 = rand.Next(1, 7);
                puntajeJugador += dado1 + dado2;

                Console.WriteLine($"Has lanzado {dado1} y {dado2}. Tu puntuación inicial es {puntajeJugador}.");

                // Opción de pedir otro dado
                while (true)
                {
                    Console.WriteLine("¿Quieres pedir otro dado? (s/n)");
                    string respuesta = Console.ReadLine().ToLower();

                    if (respuesta == "s")
                    {
                        int dado = rand.Next(1, 7);
                        puntajeJugador += dado;
                        Console.WriteLine($"Has lanzado un {dado}. Tu nueva puntuación es {puntajeJugador}.");

                        if (puntajeJugador > 21)
                        {
                            Console.WriteLine("Te has pasado de 21. ¡Has perdido!");
                            return;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                // Turno de la máquina
                Console.WriteLine("\nTurno de la máquina...");
                while (puntajeMaquina <= 16)
                {
                    int dado = rand.Next(1, 7);
                    puntajeMaquina += dado;
                    Console.WriteLine($"La máquina ha lanzado un {dado}. Su puntuación total es {puntajeMaquina}.");
                }

                if (puntajeMaquina > 21)
                {
                    Console.WriteLine("La máquina se ha pasado de 21. ¡Has ganado!");
                }
                else if (puntajeJugador > puntajeMaquina)
                {
                    Console.WriteLine($"Tu puntuación: {puntajeJugador}. Puntuación de la máquina: {puntajeMaquina}. ¡Has ganado!");
                }
                else if (puntajeJugador == puntajeMaquina)
                {
                    Console.WriteLine($"Tu puntuación: {puntajeJugador}. Puntuación de la máquina: {puntajeMaquina}. ¡Es un empate!");
                }
                else
                {
                    Console.WriteLine($"Tu puntuación: {puntajeJugador}. Puntuación de la máquina: {puntajeMaquina}. ¡Has perdido!");
                }

                Console.ReadKey();
            }

            public void JugarConAmigos()
            {
                List<int> puntajesJugadores = new List<int>();

                Console.WriteLine("\nModo: Jugar con amigos (todos contra la máquina)");
                Console.WriteLine("¿Cuántos amigos van a jugar (además de usted)?");
                int numAmigos = int.Parse(Console.ReadLine());
                int numJugadores = numAmigos + 1; // Usted más sus amigos

                // Todos los jugadores reciben su puntuación inicial
                for (int i = 0; i < numJugadores; i++)
                {
                    int dado1 = rand.Next(1, 7);
                    int dado2 = rand.Next(1, 7);
                    int puntajeInicial = dado1 + dado2;

                    Console.WriteLine($"\nJugador {i + 1} ha lanzado {dado1} y {dado2}. Puntuación inicial: {puntajeInicial}.");
                    puntajesJugadores.Add(puntajeInicial);
                }

                // Cada jugador puede pedir otro dado
                for (int i = 0; i < numJugadores; i++)
                {
                    Console.WriteLine($"\nTurno del Jugador {i + 1} para pedir otro dado:");
                    while (true)
                    {
                        Console.WriteLine($"Jugador {i + 1}, tu puntuación actual es {puntajesJugadores[i]}.");
                        Console.WriteLine("¿Quieres pedir otro dado? (s/n)");
                        string respuesta = Console.ReadLine().ToLower();

                        if (respuesta == "s")
                        {
                            int dado = rand.Next(1, 7);
                            puntajesJugadores[i] += dado;
                            Console.WriteLine($"Has lanzado un {dado}. Tu nueva puntuación es {puntajesJugadores[i]}.");

                            if (puntajesJugadores[i] > 21)
                            {
                                Console.WriteLine("Te has pasado de 21. ¡Pierdes este turno!");
                                puntajesJugadores[i] = 0;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                {

                    // Turno de la máquina contra cada jugador
                    for (int i = 0; i < numJugadores; i++)
                    {
                        Console.WriteLine($"\nTurno de la máquina contra el Jugador {i + 1}:");
                        int puntajeMaquina = 0;
                        while (puntajeMaquina <= 16)
                        {
                            int dado = rand.Next(1, 7);
                            puntajeMaquina += dado;
                            Console.WriteLine($"La máquina ha lanzado un {dado}. Su puntuación total es {puntajeMaquina}.");
                        }

                        int puntajeJugador = puntajesJugadores[i];

                        if (puntajeMaquina > 21)
                        {
                            Console.WriteLine("La máquina se ha pasado de 21. ¡El Jugador {i + 1} gana!");
                        }
                        else if (puntajeJugador > 21)
                        {
                            Console.WriteLine("El Jugador {i + 1} se ha pasado de 21. ¡La máquina gana!");
                        }
                        else if (puntajeJugador > puntajeMaquina)
                        {
                            Console.WriteLine($"Jugador {i + 1}: {puntajeJugador} puntos. Máquina: {puntajeMaquina} puntos. ¡El Jugador {i + 1} gana!");
                        }
                        else if (puntajeJugador == puntajeMaquina)
                        {
                            Console.WriteLine($"Jugador {i + 1}: {puntajeJugador} puntos. Máquina: {puntajeMaquina} puntos. ¡Es un empate!");
                        }
                        else
                        {
                            Console.WriteLine($"Jugador {i + 1}: {puntajeJugador} puntos. Máquina: {puntajeMaquina} puntos. ¡La máquina gana!");
                        }
                        
                    }

                    Console.ReadKey();
                }
            }
        }
    }

}

