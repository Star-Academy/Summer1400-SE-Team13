import java.util.*;

public class Main {
    static void run(String searchWord) {
        GetInput getInput = new GetInput("home/melika/Desktop/codes/codestar/phase1/EnglishData");
        HashMap<Integer, String> hashMap = getInput.readContent();
        InvertedIndex invertedIndex = new InvertedIndex();
        
        for (int key : hashMap.keySet()) {
            String docString = hashMap.get(key);
            Tokenizer tokenizer = new Tokenizer(docString);
            HashSet<String> wordsSet = tokenizer.tokenize();
            invertedIndex.addDoc(wordsSet, key);
        }

        HashSet<Integer> foundDocs = invertedIndex.getWordDocs(searchWord);
        System.out.println(foundDocs);
    }
    
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String searchWord = scanner.nextLine();
        run(searchWord);
    }
}
