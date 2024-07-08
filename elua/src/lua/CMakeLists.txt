file(GLOB_RECURSE luafiles "*.h" "*.c")

add_library(elua STATIC ${luafiles})