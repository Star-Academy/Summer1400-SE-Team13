package test;

import org.junit.Before;
import src.*;
import java.util.*;
import org.junit.Test;
import static org.junit.Assert.*;
import org.mockito.Mock;
import org.mockito.Mockito;


public class FilterHandlerTest {
    @Mock
    PlusFilter plusFilter;
    @Mock
    MinusFilter minusFilter;
    @Mock
    NoSignFilter noSignFilter;
    @Mock
    InvertedIndex invertedIndex;

    @Before
    public void setup() {
//        invertedIndex.addDoc(new HashSet<>(Arrays.asList("s1", "s2", "s3")), 1);
//        invertedIndex.addDoc(new HashSet<>(Arrays.asList("s1", "s4", "s5")), 2);
//        invertedIndex.addDoc(new HashSet<>(Arrays.asList("s4", "s6")), 3);
        Mockito.when(invertedIndex.getWordDocs("s1")).thenReturn(new HashSet<>(Arrays.asList(1,2)));
        Mockito.when(invertedIndex.getWordDocs("s2")).thenReturn(new HashSet<>(Collections.singleton(1)));
        Mockito.when(invertedIndex.getWordDocs("s3")).thenReturn(new HashSet<>(Collections.singleton(1)));
        Mockito.when(invertedIndex.getWordDocs("s4")).thenReturn(new HashSet<>(Collections.singleton(2)));



    }

    @Test
    public void testFilter() {
        FilterHandler filterHandler = new FilterHandler(invertedIndex, plusFilter, noSignFilter, minusFilter);
        String[] commandWords = { "+s1", "-s2", "s6" };
        HashSet<Integer> actualResult = filterHandler.filter(commandWords);
        HashSet<Integer> expectedResult = new HashSet<>();
        assertEquals(expectedResult, actualResult);
    }
}
