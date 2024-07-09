cmake_minimum_required(VERSION 3.20)

project(elua)
set(CMAKE_CXX_STANDARD 11)

set(SRC_DIR ${CMAKE_CURRENT_SOURCE_DIR}/src/lua)

file(GLOB SRC_FILES_LUAC
    ${SRC_DIR}/*.c
    ${SRC_DIR}/*.h
    ${SRC_DIR}/*.cpp
    ${SRC_DIR}/*.hpp
)
list(REMOVE_ITEM SRC_FILES_LUAC ${SRC_DIR}/lua.c ${SRC_DIR}/lua.h)
add_executable(eluac ${SRC_FILES_LUAC})
if(UNIX)
    target_link_libraries(eluac m)
endif()


file(GLOB SRC_FILES_LUA
    ${SRC_DIR}/*.c
    ${SRC_DIR}/*.h
    ${SRC_DIR}/*.cpp
    ${SRC_DIR}/*.hpp
)
list(REMOVE_ITEM SRC_FILES_LUA ${SRC_DIR}/luac.c)
add_executable(elua ${SRC_FILES_LUA})
if(UNIX)
    target_link_libraries(elua m)
endif()

add_library(lua STATIC ${SRC_FILES_LUA})