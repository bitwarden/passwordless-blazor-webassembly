import "./Passwordless.min.js";

export function init(apiKey, apiUrl) {
    return new Passwordless.Client({apiKey, apiUrl});
}