package test;

import src.*;
import java.util.*;
import static org.junit.Assert.*;
import org.junit.Test;

public class PlusFilterTest {

    private PlusFilter plusFilter = new PlusFilter();

    @Test
    public void testFilter() {
        HashSet<Integer> expectedResult = new HashSet<>(Arrays.asList(1, 2, 3, 4, 5));
        HashSet<Integer> res = new HashSet<>(Arrays.asList(1, 2, 3));
        HashSet<Integer> docs = new HashSet<>(Arrays.asList(4, 5));
        plusFilter.filter(res, docs);
        assertEquals(expectedResult, res);
    }

}
