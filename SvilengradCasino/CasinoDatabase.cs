namespace SvilengradCasino
{
    internal class CasinoDatabase
    {
        internal class DatabaseCreation
        {
            public static void CreatePlayersFile()
            {
                string path = @"Players.txt";

                if (!File.Exists(path))
                {
                    File.Create(path);
                }
            }
        }

        internal class PlayerManipulation
        {
            public static void Register(Player player)
            {
                string path = @"Players.txt";

                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(player.ToString());
                }
            }

            public static void RemovePlayer(Player player)
            {
                string path = @"Players.txt";

                string[] lines = File.ReadAllLines(path);

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(player.Username))
                    {
                        lines[i] = string.Empty;
                        break;
                    }
                }

                File.WriteAllLines(path, lines);
            }

            public static void UpdatePlayer(Player player)
            {
                string path = @"Players.txt";

                string[] lines = File.ReadAllLines(path);

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(player.Username))
                    {
                        lines[i] = player.ToString();
                        break;
                    }
                }

                File.WriteAllLines(path, lines);
            }

            public static Player GetPlayer(string username)
            {
                string path = @"Players.txt";

                string[] lines = File.ReadAllLines(path);

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(username))
                    {
                        string[] playerInfo = lines[i].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        string playerUsername = playerInfo[1];
                        string playerPassword = playerInfo[3];
                        decimal playerBalance = decimal.Parse(playerInfo[5]);

                        Player player = new Player(playerUsername, playerPassword, playerBalance);

                        return player;
                    }
                }

                return null;
            }

            public static bool IsRegistered(string username, string password)
            {
                string path = @"Players.txt";

                string[] lines = File.ReadAllLines(path);

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(username) && lines[i].Contains(password))
                    {
                        return true;
                    }
                }

                return false;
            }

            public static bool IsUsernameExist(string username)
            {
                string path = @"Players.txt";

                string[] lines = File.ReadAllLines(path);

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(username))
                    {
                        return true;
                    }
                }

                return false;
            }


        }
    }
}
