using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectEuler.Solutions
{
    public class SolutionLoader
    {
        public static IEnumerable<T> Load<T>(string[] paths) where T : class
        {
            string[] pluginPaths = paths;
           
            return pluginPaths.SelectMany(pluginPath =>
            {
                var pathsToCheck = Directory.GetFiles(pluginPath, "*.dll", SearchOption.AllDirectories)
                    .Where(x=>!x.Contains("obj\\Debug\\"));
                return pathsToCheck.SelectMany(ptc =>
                {
                    Assembly pluginAssembly = LoadPlugin(ptc);
                    return CreateCommands<T>(pluginAssembly);
                }).Where(x=>x!= null);
              
            });
        }

        static Assembly LoadPlugin(string relativePath)
        {
            // Navigate up to the solution root
            string root = Path.GetFullPath(Path.Combine(
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(
                            Path.GetDirectoryName(
                                Path.GetDirectoryName(typeof(SolutionLoader).Assembly.Location)))))));

            string pluginLocation = Path.GetFullPath(Path.Combine(root, relativePath.Replace('\\', Path.DirectorySeparatorChar)));
            Console.WriteLine($"Loading commands from: {pluginLocation}");
            PluginLoadContext loadContext = new PluginLoadContext(pluginLocation);
            return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
        }

        static IEnumerable<T> CreateCommands<T>(Assembly assembly) where T : class
        {
            int count = 0;

            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(T).IsAssignableFrom(type))
                {
                    T result = Activator.CreateInstance(type) as T;
                    if (result != null)
                    {
                        count++;
                        yield return result;
                    }
                }
            }

            if (count == 0)
            {
                yield return null;
                //string availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));
                //throw new ApplicationException(
                //    $"Can't find any type which implements ICommand in {assembly} from {assembly.Location}.\n" +
                //    $"Available types: {availableTypes}");
            }
        }
    }
}
