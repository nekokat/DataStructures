namespace LinkedListBase
{
    public enum Type 
    {
        Singly,// List nodes contains, one link to Next a value
        Doubly,// List nodes contains, besides the next-node link, a second link field pointing to the 'previous' node in the sequence
        Multiply,// List nodes contains two or more link fields
        Circular,// List's last node pointer points to the first node
        Empty,//An empty list is a list that contains no data records
    }
}