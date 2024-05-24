self.addEventListener('install', (event) => {
    console.log('Service worker installed.');
    event.waitUntil(
        caches.open('v1').then((cache) => {
            return cache.addAll([
                '/',
                '/index.html',
                '/manifest.json',
                '/_framework/blazor.webassembly.js',
                // Aggiungi altri file che desideri mettere in cache
            ]);
        })
    );
});

self.addEventListener('fetch', (event) => {
    event.respondWith(
        caches.match(event.request).then((response) => {
            return response || fetch(event.request);
        })
    );
});

self.addEventListener('activate', (event) => {
    console.log('Service worker activated.');
    event.waitUntil(
        caches.keys().then((keyList) => {
            return Promise.all(keyList.map((key) => {
                if (key !== 'v1') {
                    return caches.delete(key);
                }
            }));
        })
    );
});
