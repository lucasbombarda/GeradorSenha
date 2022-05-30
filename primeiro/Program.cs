using System;

namespace geradorSenha
{
    class GeradorSenha
    {
        static void Main()
        {
            char resposta = 'S';
            int tamanho_senha = 0;
            while (resposta == 'S' || resposta == 's')
            {
                while (true)
                {
                    try
                    {
                        Console.Clear();
                        Console.Write("Insira o tamanho da senha: \n>>> ");
                        tamanho_senha = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Insira um número válido!");
                        Console.ReadLine();
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Número muito grande! Insira um número menor!");
                        Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erro não especificado: "+ e);
                        Console.ReadLine();
                    }
                }

                string senha = "";
                senha = gera_senha(tamanho_senha);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("A senha gerada foi: " + senha);

                    Console.Write("\nDeseja gerar outra senha? [S/N]\n>>> ");
                    try
                    {
                        resposta = char.Parse(Console.ReadLine());
                        if (((resposta == 'S') || (resposta == 's')) || ((resposta == 'N') || (resposta == 'n')))
                            break;
                        else
                            msg_erro();
                    }
                    catch (FormatException)
                    {
                        msg_erro();
                    }
                }
            }

            static string gera_senha(int tamanho)
            {
                string minusculas = "abcdefghijklmnopqrstuvwxyz";
                string maiusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string numeros = "1234567890";
                string especial = "*@/$%&#!?:;><=-+";
                string senha = "";

                for (int i = 1; i <= tamanho; i++)
                {
                    Random r = new Random();
                    if (i % 4 == 0) // MINUSCULA
                        senha += minusculas[r.Next(minusculas.Length)];

                    else if (i % 3 == 0) // NUMERO
                        senha += numeros[r.Next(numeros.Length)];

                    else if (i % 2 == 0) // ESPECIAL
                        senha += especial[r.Next(especial.Length)];

                    else // MAIUSCULA
                        senha += maiusculas[r.Next(maiusculas.Length)];
                }
                senha = embaralha(senha);
                return senha;
            }

            static void msg_erro()
            {
                Console.WriteLine("Digite apenas caracteres válidos!");
                Console.ReadLine();
            }

            static string embaralha(string str)
            {
                char[] array = str.ToCharArray();
                Random rng = new Random();
                int n = array.Length;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    var value = array[k];
                    array[k] = array[n];
                    array[n] = value;
                }
                return new string(array);
            }
        }
    }
}