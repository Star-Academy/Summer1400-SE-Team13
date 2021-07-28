package test;

import src.*;
import java.util.*;
import static org.junit.jupiter.api.Assertions.assertEquals;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

public class InvertedIndexTest {

    private static InvertedIndex invertedIndex = new InvertedIndex();
    private static HashMap<String, HashSet<Integer>> testWordsMap = new HashMap<>();;

    @BeforeAll
    static void initWordsmap() {
        HashSet<Integer> h1 = new HashSet<>();
        h1.add(1);
        HashSet<Integer> h2 = new HashSet<>();
        h2.add(1);
        HashSet<Integer> h3 = new HashSet<>();
        h3.add(1);
        testWordsMap.put("str1", h1);
        testWordsMap.put("str2", h2);
        testWordsMap.put("str3", h3);

        HashSet<String> docWords = new HashSet<>();
        docWords.add("str1");
        docWords.add("str2");
        docWords.add("str3");
        int docId = 1;
        invertedIndex.addDoc(docWords, docId);
    }

    @Test
    public void testAddDocs() {

        assertEquals(testWordsMap, invertedIndex.getWordsMap());
    }

    @Test
    public void testGetWordDocs() {
        System.out.println(testWordsMap);
        HashSet<Integer> wordDocs = new HashSet<>(Arrays.asList(1));
        HashSet<Integer> tmp = invertedIndex.getWordDocs("str1");

        System.out.println(tmp);
        assertEquals(wordDocs, tmp);
    }
}