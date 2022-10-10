from xml.dom import INDEX_SIZE_ERR
import cv2
import numpy as np
import os
import shutil
import glob
import time
from cv2 import aruco
W=400
H=400
dir=r"."

dict_aruco = aruco.Dictionary_get(aruco.DICT_4X4_50)
parameters = aruco.DetectorParameters_create()

def on_error(path):
    shutil.move(path,dir+"/error/"+os.path.basename(path))
    print("errorフォルダに移動しました：",path)

for path in glob.glob(dir+"/*.jpg"):
    raw = cv2.imread(path)
    
    gray = cv2.cvtColor(raw, cv2.COLOR_RGB2GRAY)
    corners, ids, rejectedImgPoints = aruco.detectMarkers(gray, dict_aruco, parameters=parameters)
    if ids is None or len(ids)!=5:
        print("マーカーがうまく読み取れなかった")
        on_error(path)
        continue
    
    ids=np.array([i[0] for i in ids])
    idx=np.argsort(ids)
    ids=ids[idx]
    pos= np.array([np.mean(c,axis=1).reshape(-1) for c in corners] ) [idx,:]
    marker_id=ids[-1]-10
    if (ids[:4] != np.array([0,1,2,3])).any() or marker_id<0:
        print("マーカー番号が変だった")
        on_error(path)
        continue
    dist_pos=np.array(((0,0),(0,H),(W,H),(W,0) )).astype(np.float32)
    src_pos=pos[:4,:].astype(np.float32)

    M= cv2.getPerspectiveTransform(src_pos,dist_pos)
    src = cv2.warpPerspective(raw, M,(W,H))    
    mask = cv2.imread("mask/mask_%d.png"%(marker_id),0)

    
    # Point 2: 元画像をBGR形式からBGRA形式に変換
    dst = cv2.cvtColor(src, cv2.COLOR_BGR2BGRA)
    dst[:,:,3] = mask
    # png画像として出力
    tt=int(time.time())
    
    out_tmp=dir+"/tmp.png"
    out_file=dir+"/in/%d_%d_"%(marker_id,tt )+ os.path.splitext(os.path.basename(path))[0]+".png"
    cv2.imwrite(out_tmp, dst)
    shutil.move(out_tmp,out_file)
    shutil.move(path,dir+"/used/%d_"%(tt) +os.path.basename(path))
    print("投入成功！",path)