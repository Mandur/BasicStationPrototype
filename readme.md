# LBS test implementation

In order to make it work:

1. Clone [LBS](https://github.com/lorabasics/basicstation) with WSL (or linux) and make it
1. cd in examples/live-s2.sm.tc
1. rm all files cups*
1. Add a file on the folder called tc.uri. Its content should be ws://<your-ip>:5000
    To find your ip in wsl run `cat /etc/resolv.conf`
1. start the .net solution and run make on the LBS
1. The handshake will be completed.
