import React, { useState } from "react";
import "./FileDropZone.css";

const FileDropZone = ({ onFileUpload }) => {
  const [isDragging, setIsDragging] = useState(false);

  const handleDragEnter = (e) => {
    e.preventDefault();
    setIsDragging(true);
  };

  const handleDragOver = (e) => {
    e.preventDefault();
  };

  const handleDragLeave = (e) => {
    e.preventDefault();
    setIsDragging(false);
  };

  const handleDrop = (e) => {
    e.preventDefault();
    onFileUpload(e.nativeEvent.dataTransfer.files);
  };

  return (
    <>
      <h2>File Drag & Drop</h2>
      <div
        id="dropZone"
        className={`border dropzone ${isDragging ? "dragging" : ""}`}
        onDragEnter={handleDragEnter}
        onDragOver={handleDragOver}
        onDragLeave={handleDragLeave}
        onDrop={handleDrop}
      >
        <p>Drop your files here</p>
        <div id="file-previews"></div>
        <div id="upload-progress"></div>
      </div>

      <h4>Uploaded Files:</h4>
      <ul id="uploadResult"></ul>
    </>
  );
};

export default FileDropZone;
