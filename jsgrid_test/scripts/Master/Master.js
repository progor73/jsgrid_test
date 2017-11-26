function CallServer(url, data, function_call_back) {

    $.ajax({
        type: "GET",
        url: url,
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (msg) {
            if (msg.hasOwnProperty("d")) {

                function_call_back(msg.d);

            }
        }
    }
);
}