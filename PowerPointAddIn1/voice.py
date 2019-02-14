#!/usr/bin/env python

# Copyright 2017 Google Inc. All Rights Reserved.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#      http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

"""Google Cloud Speech API sample application using the REST API for batch
processing.

Example usage:
    python transcribe.py resources/audio.raw
    python transcribe.py gs://cloud-samples-tests/speech/brooklyn.flac
"""

# [START import_libraries]
import argparse
import io
# [END import_libraries]
def transferToMono(speech_file):
    from pydub import AudioSegment
   # AudioSegment.converter = r"C:\\Users\\Yoni Kazarski\\Desktop\\ffmpeg-20180322-ed0e0fe-win64-static\\bin\\ffmpeg.exe"
    sound = AudioSegment.from_wav(speech_file)
    sound = sound.set_frame_rate(16000)
    sound = sound.set_channels(1)
    sound.export(speech_file, format="wav")
    import soundfile
    data, samplerate = soundfile.read(speech_file)
    soundfile.write(speech_file, data, samplerate, subtype='PCM_16')


# [START def_transcribe_file]
def transcribe_file(speech_file,lang,credentials_path):
    transferToMono(speech_file)
    """Transcribe the given audio file."""
    from google.cloud import speech
    from google.cloud.speech import enums
    from google.cloud.speech import types
    import os
    os.environ["GOOGLE_APPLICATION_CREDENTIALS"] = credentials_path
    client = speech.SpeechClient()

    # [START migration_sync_request]
    # [START migration_audio_config_file]
    with io.open(speech_file, 'rb') as audio_file:
        content = audio_file.read()

    audio = types.RecognitionAudio(content=content)
    config = types.RecognitionConfig(
        encoding=enums.RecognitionConfig.AudioEncoding.LINEAR16,
        sample_rate_hertz=16000,
        language_code=lang)
    # [END migration_audio_config_file]

    # [START migration_sync_response]
    response = client.recognize(config, audio)
    # [END migration_sync_request]
    # Each result is for a consecutive portion of the audio. Iterate through
    # them to get the transcripts for the entire audio file.
    for result in response.results:
        # The first alternative is the most likely one for this portion.
        print('Transcript: {}'.format(result.alternatives[0].transcript))
    # [END migration_sync_response]
# [END def_transcribe_file]


# [START def_transcribe_gcs]
def transcribe_gcs(gcs_uri):
    """Transcribes the audio file specified by the gcs_uri."""
    from google.cloud import speech
    from google.cloud.speech import enums
    from google.cloud.speech import types
    client = speech.SpeechClient()

    # [START migration_audio_config_gcs]
    audio = types.RecognitionAudio(uri=gcs_uri)
    config = types.RecognitionConfig(
        encoding=enums.RecognitionConfig.AudioEncoding.LINEAR16,
        sample_rate_hertz=16000,
        language_code='en-US')
    # [END migration_audio_config_gcs]

    response = client.recognize(config, audio)
    # Each result is for a consecutive portion of the audio. Iterate through
    # them to get the transcripts for the entire audio file.
    for result in response.results:
        # The first alternative is the most likely one for this portion.
        print('Transcript: {}'.format(result.alternatives[0].transcript))
# [END def_transcribe_gcs]


if __name__ == '__main__':
    parser = argparse.ArgumentParser(
        description=__doc__,
        formatter_class=argparse.RawDescriptionHelpFormatter)
    parser.add_argument(
        'path', help='File or GCS path for audio file to be recognized')
    parser.add_argument(
        'language', help='en-US')
    parser.add_argument(
        'credentialsPath', help='Credentials Json file')

    args = parser.parse_args()

    if args.path.startswith('gs://'):
        transcribe_gcs(args.path,args.language,args.credentialsPath)
    else:
        transcribe_file(args.path,args.language,args.credentialsPath)
