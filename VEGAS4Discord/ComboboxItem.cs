using System.Collections.Specialized;

namespace VegasDiscordRPC {
    public struct ComboboxItem<T> {
        public string Name { get; set; }
        public T Value { get; set; }

        public override string ToString() {
            return Name;
        }

        public ComboboxItem(string name, T value) {
            Name = name;
            Value = value;
        }
    }
}