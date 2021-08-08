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
    public void testFullTextSearch_complicated() {
        HashSet<Integer> expect = new HashSet<>();
        FullTextSearch fullTextSearch = new FullTextSearch("+hello +bye +raha -melika java", invertedIndex, tokenizer, docsFileReader,
                filterHandler);
        assertEquals(expect, fullTextSearch.run());
    }

    @Test
    public void testFullTextSearch_plusOnly() {
        HashSet<Integer> expect = new HashSet<>();
        FullTextSearch fullTextSearch = new FullTextSearch("+doesntExist", invertedIndex, tokenizer, docsFileReader,
                filterHandler);
        assertEquals(expect, fullTextSearch.run());
    }

    @Test
    public void testFullTextSearch_minusOnly() {
        HashSet<Integer> expect = new HashSet<>();
        FullTextSearch fullTextSearch = new FullTextSearch("-melika -java", invertedIndex, tokenizer, docsFileReader,
                filterHandler);
        assertEquals(expect, fullTextSearch.run());
    }

    @Test
    public void testFullTextSearch_noSignOnly() {
        HashSet<Integer> expect = new HashSet<>(Arrays.asList(3));
        FullTextSearch fullTextSearch = new FullTextSearch("melika python", invertedIndex, tokenizer, docsFileReader,
                filterHandler);
        assertEquals(expect, fullTextSearch.run());
    }

    @Test
    public void testFullTextSearch_plusAndNoSignOnly() {
        HashSet<Integer> expect = new HashSet<>(Arrays.asList(2));
        FullTextSearch fullTextSearch = new FullTextSearch("+hello you", invertedIndex, tokenizer, docsFileReader,
                filterHandler);
        assertEquals(expect, fullTextSearch.run());
    }
}
