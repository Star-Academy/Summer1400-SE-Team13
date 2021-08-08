package test;

import src.*;
import java.util.*;
import static org.junit.Assert.*;
import org.junit.Test;
import org.junit.Before;


public class DocsFileReaderTest {
    private DocsFileReader docsFileReader;
    private String docContentExpected;
    private int docIDExpected;
    private HashMap<Integer, String> expectedValue;

    @Before
    public void setupExpectedValues(){
        docsFileReader = new DocsFileReader();
        docContentExpected = "Hello World.";
        docIDExpected = 1;
        expectedValue = new HashMap<>();
        expectedValue.put(docIDExpected, docContentExpected);
    }

    @Test
    public void testFileReader() {
        final String fileAddress = "Phase1/test/SampleFolder";
        HashMap<Integer, String> actualValue = docsFileReader.readContent(fileAddress);
        assertEquals(expectedValue.get(1), actualValue.get(1));
    }
}
