import java.util.HashSet;

interface Filter {
    void filter(HashSet<Integer> result, HashSet<Integer> docs);
}
