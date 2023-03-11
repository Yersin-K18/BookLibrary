window.onload = () => {
    var searchElement = document.querySelector("#search-bar");

    var typingTimer;
    var doneTypingInterval = 1000;
    var oldText = "";

    searchElement.addEventListener("keyup", () => {
        // Xóa bộ đếm thời gian hiện tại
        clearTimeout(typingTimer);
        // Đặt bộ đếm thời gian mới
        typingTimer = setTimeout(Search, doneTypingInterval);
    });

    function Search() {
        if (searchElement.value == oldText || searchElement.value == "") {
            return;
        }
        oldText = searchElement.value;
        fetch("/Search/PreSearch?query=" + oldText, {
            "headers": {
                "accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7",
                "accept-language": "vi,en-US;q=0.9,en;q=0.8",
                "sec-ch-ua": "\"Chromium\";v=\"110\", \"Not A(Brand\";v=\"24\", \"Microsoft Edge\";v=\"110\"",
                "sec-ch-ua-mobile": "?0",
                "sec-ch-ua-platform": "\"Windows\"",
                "sec-fetch-dest": "document",
                "sec-fetch-mode": "navigate",
                "sec-fetch-site": "none",
                "sec-fetch-user": "?1",
                "upgrade-insecure-requests": "1"
            },
            "referrerPolicy": "strict-origin-when-cross-origin",
            "body": null,
            "method": "GET",
            "mode": "cors",
            "credentials": "omit"
        }).then(res => {
            res.text().then(html => {
                const parser = new DOMParser();
                const newDocument = parser.parseFromString(html, 'text/html');
                var result = document.querySelector("#result-search-bar");
                result.innerHTML = newDocument.querySelector("div").innerHTML;
            });
        });
    };
};