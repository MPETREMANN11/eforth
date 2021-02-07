( Implement Vocabularies )
: forth   [ current @ ] literal context ! ;
: vocabulary ( "name" ) create 0 , current @ 2 cells + , does> cell+ context ! ;
: definitions   context @ current ! ;
: >name-length ( xt -- n ) dup 0= if exit then >name nip ;
: vlist   0 context @ @ begin dup >name-length while onlines dup see. >link repeat 2drop cr ;
: transfer ( "name" ) ' context @ begin 2dup @ <> while @ >link& repeat nip
                      dup @ swap dup @ >link swap ! current @ @ over >link& !
                      current @ ! ;

( Hide some words in an internals vocabulary )
vocabulary internals   internals definitions
transfer branch   transfer 0branch   transfer donext   transfer dolit
transfer 'notfound   transfer notfound
transfer immediate?
transfer input-buffer   transfer ?echo   transfer ?echo-prompt
transfer evaluate1   transfer evaluate-buffer
transfer 'sys   transfer 'heap
transfer aliteral
transfer leaving(   transfer )leaving   transfer leaving   transfer leaving,
transfer (do)   transfer (?do)   transfer (+loop)
transfer parse-quote
transfer digit
transfer $@
transfer see.   transfer see-loop    transfer >name-length   transfer exit=
transfer see-one
transfer tib-setup   transfer input-limit
forth definitions