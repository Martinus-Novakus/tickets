function jsApi(){
    const apiRoot = `${window.location.origin}`;

    function handleResponse(resp){
        if(!resp) return;

        if(resp.status >= 400){
            throw Error(resp.statusText);
        }        

        return resp.text();
    }
    
    async function get(url){
        const response =  await fetch(apiRoot + url, {
            method: "GET",
            headers: { "Accept": "text/html" }
        })

        return handleResponse(response);
    }

    return { get }
}