define(['jquery'], function($) {
    var fillerWords = [
        'a', 'an', 'by', 'on', 'onto', 'the'  
    ];
    
    var $title = $('article.post').find('h2.title');
    
    $title.html($title.text().split(' ').map(function(word) {
        var lowerWord = word.toLowerCase(), isFiller = false;
        fillerWords.forEach(function(value, index) {
            isFiller = isFiller || lowerWord === value;
        });
        
        return "<span class='" +
            (isFiller ? "filler" : "important") +
            "'>" + word + "</span>";
    }).join('&nbsp;'));
});