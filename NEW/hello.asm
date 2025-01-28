[BITS 64]

global start

extern printf        ; from msvcrt
extern scanf         ;from msvcrt
extern ExitProcess   ; from kernel32

section .bss
    ext_key: resb 8

section .data
    string:   db '%s, %s, %s, %s, %s', 10, 0 
    jstr1:       db 'STR1', 0
    jstr2:       db 'STR2', 0
    jstr3:       db 'STR3', 0
    jstr4:       db 'STR4', 0
    jstr5:       db 'STR5', 0

    startmsg: db '<----START OF PROGRAM----->', 10, 0
    endmsg:   db '<---END OF PROGRAM--->', 10, 'Press any key to exit...', 0
    ext_frm:  db '%s', 0           ; Format string for scanf

section .text
start:
    sub     rsp, 40                ; Align the stack to 16 bytes for Windows ABI compliance

    mov     rcx, startmsg
    call    printf
    ;=================[PROGRAM START]=======================

    mov     rcx, string
    mov     rdx, jstr1
    mov     r8,  jstr2
    mov     r9,  jstr3
    lea     rax, qword [jstr4]
    mov     qword [rsp + 32], rax
    lea     rax, qword [jstr5]
    mov     qword [rsp + 40], rax
    call    printf
    
    ;=================[PROGRAM END]=======================
_exit: ;EXIT
    mov     rcx, endmsg            ; Load the address of the end message
    call    printf                 ; Print the end message

    mov     rdx, ext_key           ; Load the address of the buffer for scanf
    mov     rcx, ext_frm           ; Load the address of the scanf format string
    call    scanf                  ; Wait for input (simulating "Press any key")

    xor     ecx, ecx               ; Set exit code to 0
    call    ExitProcess            ; Exit the program