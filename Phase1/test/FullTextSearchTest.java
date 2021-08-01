package test;

import src.*;
import java.util.*;
import static org.junit.Assert.*;
import org.junit.Test;
import org.junit.Before;

public class FullTextSearchTest {
    private InvertedIndex invertedIndex;
    private DocsFileReader docsFileReader;
    private FilterHandler filterHandler;
    private Tokenizer tokenizer;
    private PlusFilter plusFilter;
    private MinusFilter minusFilter;
    private NoSignFilter noSignFilter;

    @Before
    public void setup() {
        invertedIndex = new InvertedIndex();
        tokenizer = new Tokenizer();
        docsFileReader = new DocsFileReader();
        plusFilter = new PlusFilter();
        noSignFilter = new NoSignFilter();
        minusFilter = new MinusFilter();
        filterHandler = new FilterHandler(invertedIndex, plusFilter, noSignFilter, minusFilter);
    }

    @Test
    public void testFullTextSearch() {
        HashSet<Integer> expect = new HashSet<>(Arrays.asList(1, 2));
        FullTextSearch fullTextSearch = new FullTextSearch("hello", invertedIndex, tokenizer, docsFileReader,
                filterHandler);
        assertEquals(expect, fullTextSearch.run());
    }
}
