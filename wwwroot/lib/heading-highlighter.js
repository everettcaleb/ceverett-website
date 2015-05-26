//Splits the title of a post into spans classed as either 'filler' or 'important' used for styling
define(['jquery'], function($) {
    var fillerWords = [
        'a', 'an', 'by', 'of', 'on', 'onto', 'the'  
    ], fillerLen = fillerWords.length;
    
    function isFillerWord(word) {
        var i = 0;
        word = word.toLowerCase();
        
        for(; i < fillerLen; ++i) {
            if(word === fillerWords[i]) {
                return true;
            }
        }
        
        return false;
    }
    
    $('article.post').find('h2.title').each(function(i, title) {
        title.innerHTML = title.textContent.split(' ').map(function(word) {
            return "<span class='" +
                (isFillerWord(word) ? "filler" : "important") +
                "'>" + word + "</span>";
        }).join('&nbsp;');
    });
});