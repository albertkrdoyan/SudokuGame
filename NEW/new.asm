; Compile with: nasm -f win64 malloc_free.asm -o malloc_free.obj
; Link with: GoLink /console /entry main malloc_free.obj msvcrt.dll kernel32.dll

section .data
    size dq 100                      ; Size of memory to allocate (100 bytes)
    msg_malloc db "Memory allocated at: %p", 10, 0
    msg_free db "Memory freed.", 10, 0
    msg_error db "Memory allocation failed.", 10, 0

section .bss
    mem resq 1                       ; To store the pointer to the allocated memory

section .text
    extern malloc, free, printf, ExitProcess

    global start
start:
    ; Call malloc(size)
    mov rcx, [size]                  ; First argument: size of memory to allocate
    call malloc                      ; Call malloc
    test rax, rax                    ; Check if malloc returned NULL (0)
    jz allocation_failed             ; If NULL, jump to error handling
    mov [mem], rax                   ; Save allocated pointer in 'mem'

    ; Print the allocated address
    mov rcx, msg_malloc              ; First argument: message format
    mov rdx, rax                     ; Second argument: allocated pointer
    call printf                      ; Call printf(msg_malloc, rax)

    ; Call free(ptr)
    mov rcx, [mem]                   ; First argument: pointer to free
    call free                        ; Call free

    ; Print "Memory freed."
    mov rcx, msg_free                ; First argument: message
    call printf                      ; Call printf(msg_free)

    ; Exit the process
    mov rcx, 0                       ; Exit code
    call ExitProcess

allocation_failed:
    ; Print "Memory allocation failed."
    mov rcx, msg_error               ; First argument: message
    call printf                      ; Call printf(msg_error)

    ; Exit with error code
    mov rcx, 1                       ; Exit code
    call ExitProcess