Frontend rendering strategy

(Transparent) service worker proxy
Everything from cache, full page reload on invalid cache

Study material is already in HTML

First load:
 - html+js+css + study material + script when logged in
 - fetch user data, download outline
 - when logged in, download progress

Use service worker
  --> HTML from cache: invalidate whole page when a stale page was returned
  --> User data, outline: same
  --> Progress: never cached


First load:
 - main content is fastest as as theoretically possible
 - Hiccup when rest of the content is loading

Next pages with service worker
 - Full page reload causing loss of focus
   - something in cache: immediate
   - not in cache: white screen flash? (service worker can show a skeleton, onbeforeunload can make the skeleton)
 - Page reload on invalid cache


# current discussion

first/next/previous page of course/subject/exercise

load TOC on demand, navigation buttons appear afterwards



zx
