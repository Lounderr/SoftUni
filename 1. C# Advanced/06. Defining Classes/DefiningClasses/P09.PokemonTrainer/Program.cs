using System;
using System.Linq;

namespace P09.PokemonTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] cmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cmd[0] == "Tournament")
                {
                    break;
                }

                string trainerName = cmd[0];
                string pokemonName = cmd[1];
                string pokemonElement = cmd[2];
                int pokemonHealth = int.Parse(cmd[3]);

                if (Trainer.Trainers.ContainsKey(trainerName))
                {
                    Trainer.Trainers[trainerName].Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                    Trainer.Trainers.Add(trainer.Name, trainer);
                }
            }

            while (true)
            {
                string[] cmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cmd[0] == "End")
                {
                    foreach (var trainer in Trainer.Trainers.Values.OrderByDescending(x => x.NumberOfBadges))
                    {
                        Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
                    }

                    break;
                    // cmd[0] : : : : Fire, Water, Electricity
                    // check if has element => true -> +1 badge; false -> -10 Health
                    // 0 or less pokemon health -> delete from trainer collection
                    // In end print trainers sorted by amount of badges in desc order "{trainerName} {badges} {numberOfPokemon}"
                }

                foreach (var trainer in Trainer.Trainers.Values)
                {
                    if (trainer.Pokemons.Any(p => p.Element == cmd[0]))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;
                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.Remove(trainer.Pokemons[i]);
                            }
                        }
                    }
                }
            }
        }
    }
}
