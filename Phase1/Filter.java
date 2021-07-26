import java.util.HashSet;

interface Filter {

    public HashSet<Integer> filter(HashSet<Integer> result, HashSet<Integer> docs);
}