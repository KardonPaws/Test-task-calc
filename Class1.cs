using System;
using System.Drawing;

namespace ds.test.impl
{
    /// <summary>
    ///  Интерфейс плагина
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        ///  Имя плагина
        /// </summary>
        string PluginName { get; }
        /// <summary>
        ///  Версия плагина
        /// </summary>
        string Version { get; }
        /// <summary>
        ///  Картинка плагина
        /// </summary>
        Image Image { get; }
        /// <summary>
        ///  Описание плагина
        /// </summary>
        string Description { get; }
        /// <summary>
        ///  Выполнение математического оператора
        /// </summary>
        int Run(int input1, int input2);
    }
    /// <summary>
    ///  Класс, описывающий плагин
    /// </summary>
    public abstract class PluginBase : IPlugin
    {
        /// <summary>
        ///  Имя плагина
        /// </summary>
        public abstract string PluginName { get; }
        /// <summary>
        ///  Версия плагина
        /// </summary>
        public abstract string Version { get; }
        /// <summary>
        ///  Картинка плагина
        /// </summary>
        public abstract Image Image { get; }
        /// <summary>
        ///  Описание плагина
        /// </summary>
        public abstract string Description { get; }
        /// <summary>
        ///  Выполнение математического оператора
        /// </summary>
        public abstract int Run(int input1, int input2);
    }
    /// <summary>
    ///  Основной класс, обеспечивающий работу с операторами
    /// </summary>
    public static class PluginFactory
    {
        private static IPlugin[] _plugins = new IPlugin[]
        {
            new AdditionPlugin(),
            new MultiplicationPlugin(),
            new DivisionPlugin()
        };
        /// <summary>
        ///  Возвращает число плагинов, созданных в библиотеке
        /// </summary>
        public static int PluginsCount => _plugins.Length;
        /// <summary>
        ///  Возвращает все имена плагинов, созданных в библиотеке
        /// </summary>
        public static string[] GetPluginNames()
        {
            string[] names = new string[PluginsCount];
            for (int i = 0; i < PluginsCount; i++)
            {
                names[i] = _plugins[i].PluginName;
            }
            return names;
        }
        /// <summary>
        ///  Возвращает IPlugin по имени плагина, если имя не найдено - будет возвращено значение null
        /// </summary>
        public static IPlugin GetPlugin(string pluginName)
        {
            foreach (var plugin in _plugins)
            {
                if (plugin.PluginName == pluginName)
                    return plugin;
            }
            return null;
        }
    }
    /// <summary>
    ///  Плагин сложения
    /// </summary>
    public class AdditionPlugin : PluginBase
    {
        public override string PluginName => "+";
        public override string Version => "1.0";
        public override Image Image => null;
        public override string Description => "Производит сложение двух чисел.";

        public override int Run(int input1, int input2)
        {
            return input1 + input2;
        }
    }
    /// <summary>
    ///  Плагин умножения
    /// </summary>
    public class MultiplicationPlugin : PluginBase
    {
        public override string PluginName => "*";
        public override string Version => "1.0";
        public override Image Image => null;
        public override string Description => "Производит умножение двух чисел.";

        public override int Run(int input1, int input2)
        {
            return input1 * input2;
        }
    }
    /// <summary>
    ///  Плагин деления
    /// </summary>
    public class DivisionPlugin : PluginBase
    {
        public override string PluginName => "/";
        public override string Version => "1.0";
        public override Image Image => null;
        public override string Description => "Производит деление двух чисел.";

        public override int Run(int input1, int input2)
        {
            return input1 / input2;
        }
    }
}
