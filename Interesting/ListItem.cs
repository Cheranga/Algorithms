namespace Interesting
{
    public class ListItem<T>
    {
        public T Data { get; set; }
        public ListItem<T> Previous { get; set; }

        public ListItem(T data)
        {
            Data = data;
        }
    }
}