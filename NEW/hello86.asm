[BITS 32]

global start

extern printf        ;from msvcrt
extern scanf         ;from msvcrt
extern ExitProcess   ;from kernel32

section .bss
    name:   resb 128
    ext_key:resb 8

section .data
    prompt: db 'Enter your name: ',0
    frmt:   db '%s',0
    greet:  db 'Hello, %s!',0ah,0
    endmsg: db '<---END OF PROGRAM--->',10, 'Press any key to exit...', 0
    ext_frm:db '%s',0

section .text
start:
    sub     esp, 40

    mov     ecx,prompt
    push    ecx
    ;push    dword [prompt]
    call    printf
    ;add     esp, 32

    mov     edx,name
    mov     ecx,frmt
    push    edx
    push    ecx    
    call    scanf
    ;add     esp, 64

    mov     ecx, name
    push    ecx
    mov     ecx, greet
    push    ecx
    call    printf
    ;add     esp, 64

    push    0
    call    ExitProcess

;nasm -f win64 hello.asm -o hello.obj && GoLink /console hello.obj kernel32.dll msvcrt.dll && hello