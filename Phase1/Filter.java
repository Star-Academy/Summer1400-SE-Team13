import java.util.HashSet;

public abstract class Filter {

    public abstract HashSet<Integer> filter(HashSet<Integer> result, HashSet<Integer> docs);
}