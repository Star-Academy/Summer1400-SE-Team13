import java.util.HashSet;

interface Filter {
    HashSet<Integer> filter(HashSet<Integer> result, HashSet<Integer> docs);
}
