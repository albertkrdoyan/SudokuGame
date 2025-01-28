; Compile with: nasm -f win64 malloc_free.asm -o malloc_free.obj
; Link with: GoLink /console /entry main malloc_free.obj msvcrt.dll kernel32.dll

section .data
    message db "Hello from dynamically allocated memory!", 0  ; Message to copy
    size dq 100                                              ; Size to allocate
    format db "%s", 10, 0                                    ; Format string for printf
    err_malloc_msg: db "Memory allocation failed!", 10, 0  ; Inline string for error
section .bss
    mem resq 1                                               ; To store the allocated memory pointer

section .text
    extern malloc, free, printf, ExitProcess

    global main
main:
    sub rsp, 40
    ; Allocate memory using malloc
    mov rcx, [size]           ; First argument: size (100 bytes)
    call malloc               ; Call malloc
    test rax, rax             ; Check if malloc failed (rax == 0)
    jz allocation_failed      ; Jump if malloc returned NULL
    mov [mem], rax            ; Store the allocated pointer in 'mem'

    ; Copy message into allocated memory
    lea rsi, [message]        ; Source: address of 'message'
    mov rdi, rax              ; Destination: allocated memory
    mov rcx, [size]           ; Copy up to 'size' bytes
    cld                       ; Clear direction flag for forward copy
    rep movsb                 ; Copy bytes from [rsi] to [rdi]

    ; Print the message using printf
    mov rcx, format           ; First argument: format string
    mov rdx, [mem]            ; Second argument: pointer to allocated memory
    call printf               ; Call printf(format, mem)

    ; Free the allocated memory
    mov rcx, [mem]            ; First argument: pointer to free
    call free                 ; Call free

    ; Exit the program
    mov rcx, 0                ; Exit code
    call ExitProcess

allocation_failed:
    ; Print an error message if malloc failed
    mov rcx, err_malloc_msg
    call printf
    mov rcx, 1                ; Exit code for error
    call ExitProcess